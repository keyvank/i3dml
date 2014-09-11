# The i3DML Project

## WHAT THIS GIT REPOSITORY CONTAINS?
	
The repository contains the .Net Framework implementation 
of the i3MDL Project. The project uses Microsoft XNA as its
API for making connection to the graphic device. So in order
to compile and run the project on your platform, you need 
these components to be installed:

* Microsoft .Net Framework 4.0 (Or higher)
* Microsoft XNA Game Studio 4.0 (Or higher)

## WHAT IS i3DML? 

Simply, i3DML (pronounced as | ai θriː diː em el |) is an 
XML-based markup language that defines a set of rules for 
modelling 3D worlds from an XML document.

i3DML tries to introduce a new standard for 3D design which 
is independent from any other technologies from now, and it 
tries to make this concept simpler than before. Using i3DML 
you can design your World with a set of tags and attributes.

## WHY SHOULD I USE i3DML?

i3DML suggests you features that makes 3D modelling much easier 
than before:

* It can be transferred over the network
* It has a very flexible positioning System
* It uses JavaScript as the logical part of applications
* It is independent from other technologies
	
i3DML is an XML-based technology, which means you can design 
and draw your World with a set of tags and attributes, and of 
course, without a huge knowledge of Computer Graphics science.
i3DML-designed Worlds occupy small amount of space in memory, 
which means you can use i3DML as an alternative for transferring 
huge 3D scenes over a network or the Internet instead of using 
large-sized 3D models.

Anything that you see in an i3DML Application’s output is an 
Element. You can put these Elements in Container Elements. Using 
this feature you can position your Elements relative to each 
other.

i3DML uses JavaScript language as an extension for controlling 
your entire World dynamically. The scripting feature also 
provides you the i3DML Document Object Model (i3DML DOM) which
includes the components which you need to access and modify your
Worlds.
And the last thing, i3DML is independent from other technologies 
such as HTML (For example, you shouldn’t put your i3DML markup 
codes inside a HTML document) 
	
## HOW IT WORKS?

Let's take a look at the execution process of an i3DML Application. 
An i3DML Application is a simple XML document which will be kept in 
a file with the format of .i3DML. The file can be hosted in a local 
storage or it can be over the web. The client requests the i3DML file 
from the server and downloads the hosted file (The hosted file can 
be created dynamically!). In the next step, i3DML Parser does the 
document parsing for us. After the parsing, i3DML Engine will run the 
Application and apply the relations between Application elements, 
codes and resources. It also interacts with Graphics Device and 
renders the generated primitives on the screen. 

i3DML Browser includes i3DML Parser and i3DML Engine together which 
creates a flexible environment for surfing in the i3DML files.
After the i3DML document and its components is downloaded and parsed, 
the document will be dispatched to the i3DML Engine. The i3DML Engine 
starts to build the elements hierarchy which is named the i3DML Element 
Tree. Then it starts to download the application resources (Such as 
textures, sounds and etc.). After all, it enters an infinite loop until 
the application ends. Everything you see in the application output is 
drawn in that loop.

## FEW WORDS MORE
	
As I am the only developer and coordinator of this project, I need 
some other guys for further development. So if you are interested to 
contribute with this project, contact with me at my profile.

Good luck ;)
