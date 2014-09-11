/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/


float4x4 xWorld;
float4x4 xView;
float4x4 xProjection;
Texture xTexture;
bool Textured;
bool Lighting;

float Ambient;
float3 Diffuse;

float3 Light0Pos;
float Light0Power;
float3 Light1Pos;
float Light1Power;
float3 Light2Pos;
float Light2Power;
float3 Light3Pos;
float Light3Power;
float3 Light4Pos;
float Light4Power;

#define MAX_LIGHTS 4

float3 LightPositions[MAX_LIGHTS];
float3 LightColors[MAX_LIGHTS];
float LightPowers[MAX_LIGHTS];

sampler TextureSampler = sampler_state { texture = <xTexture> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = wrap; AddressV = wrap;};

struct ColoredVertexInput
{
	float4 Position:	POSITION0;
	float4 Normal:		NORMAL0;
	float4 TexCoord:	TEXCOORD0;
	float4 Color:		COLOR0;
};

struct ColoredVertexOutput
{
	float4 Position:	POSITION0;
	float4 TexCoord:	TEXCOORD0;
	float3 Normal:		TEXCOORD1;
	float4 Color:		COLOR0;
	float4 Position3D:	TEXCOORD2;
};
struct NonColoredVertexInput
{
	float4 Position:	POSITION0;
	float4 Normal:		NORMAL0;
	float4 TexCoord:	TEXCOORD0;
};

struct NonColoredVertexOutput
{
	float4 Position:	POSITION0;
	float4 TexCoord:	TEXCOORD0;
	float3 Normal:		TEXCOORD1;
	float4 Position3D:	TEXCOORD2;
};
float DotProduct(float3 lightPos, float3 pos3D, float3 normal)
{
    float3 lightDir = normalize(pos3D - lightPos);
	float ret=dot(-lightDir, normal);
    return ret>0?ret:0;  
}
ColoredVertexOutput i3DMLColoredVertexShader(ColoredVertexInput input)
{
	ColoredVertexOutput ret=(ColoredVertexOutput)0;
	float4 pos=mul(input.Position,xWorld);
	pos=mul(pos,xView);
	pos=mul(pos,xProjection);
	ret.Position=pos;
	ret.Normal=normalize(mul(input.Normal, (float3x3)xWorld));
	ret.TexCoord=input.TexCoord;
	ret.Color=input.Color;
	ret.Position3D=mul(input.Position,xWorld);
	return ret;
}

float4 i3DMLColoredPixelShader(ColoredVertexOutput input):COLOR0
{
	float4 color=tex2D(TextureSampler,input.TexCoord);
	if(!Textured)
		color = float4(1,1,1,1);
	color*=input.Color*float4(Diffuse,1);
	if(!Lighting)
		return color;
	float4 d=(float4)0;
	for(int i=0;i<MAX_LIGHTS;i++)
		d+=DotProduct(LightPositions[i],input.Position3D,input.Normal)*LightPowers[i]*float4(LightColors[i],1);
	return (Ambient+d)*color;
}
NonColoredVertexOutput i3DMLNonColoredVertexShader(NonColoredVertexInput input)
{
	NonColoredVertexOutput ret=(NonColoredVertexOutput)0;
	float4 pos=mul(input.Position,xWorld);
	pos=mul(pos,xView);
	pos=mul(pos,xProjection);
	ret.Position=pos;
	ret.Normal=normalize(mul(input.Normal, (float3x3)xWorld));
	ret.TexCoord=input.TexCoord;
	ret.Position3D=mul(input.Position,xWorld);
	return ret;
}

float4 i3DMLNonColoredPixelShader(NonColoredVertexOutput input):COLOR0
{
	float4 color=tex2D(TextureSampler,input.TexCoord);
	if(!Textured)
		color = float4(1,1,1,1);
	color*=float4(Diffuse,1);
	if(!Lighting)
		return color;
	float d=0;
	for(int i=0;i<MAX_LIGHTS;i++)
		d+=DotProduct(LightPositions[i],input.Position3D,input.Normal)*LightPowers[i]*float4(LightColors[i],1);
	return (Ambient+d)*color;
}

technique Colored
{
    pass Pass0
    {
        VertexShader = compile vs_2_0 i3DMLColoredVertexShader();
        PixelShader = compile ps_2_0 i3DMLColoredPixelShader();
    }
}
technique NonColored
{
    pass Pass0
    {
        VertexShader = compile vs_2_0 i3DMLNonColoredVertexShader();
        PixelShader = compile ps_2_0 i3DMLNonColoredPixelShader();
    }
}


