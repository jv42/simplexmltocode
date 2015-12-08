Xml2Code
========

*XML to C# Class generator*

Note:
---

I have imported this project from [Sourceforge](http://sourceforge.net/projects/simplexmltocode/) to contribute publicly my own changes over the original.

The reported last update there is 2013-03-26 (as I'm writing this).

---


This project started off as just something I wanted to do quickly to help me generate some classes
based on XML results I was receieving from a new supplier.  I tried using the XSD route and I just
found the resulting code from that system to be complicated and difficult to maintain.

I wanted something that outputted simple code in clean classes.  So I started this XML2Code generator.
This is still in it's very infant stages.  I started off creating clean code but ended up hacking a
bunch of stuff to get the job done quicker.  I am now publishing it as I feel it can help a lot of people
and if I am lucky I might get a few commits which will hopefully improve this.

How it works
============

Basically you enter the information into the form, select your xml, select your output directory and click
generate.  The system will then go through the entire XML document looking at layout, enumerations, nullables,
values, etc... and based on the XML it will try and cleverly guess data types and the code to go with them.

Known Bugs
==========

XML SchemaLocation not implemented
XML Namespace not implemented
I'm sure there are plenty more issues but as this is alpha, I ahve not discovered them yet
Comments will break the system

To Do
=====

Perhaps instead of using nullables it may be best to use XML Default Values?
Clean up the code into logical classes and separate all the various functionalities more cleverly.
Take into consideration different Charsets
Take into consideration SchemaLocations
Take into consideration XML Namespaces
Commenting and autosence
Allow URL as XML input
Remember previous settings (date format, namespace, output directory)
Lots of commenting
Lots of testing with various XML docs
Allow commenting in XML
 - Allow comments such as Required, Optional, Enumerable, Enum({strval=intval}, {strval=intval}, {strval=intval}), Type(string/int/etc...)
Generate Service methods to build the full XML object

PLEASE NOTE
===========

This was done in a rush as it was not approved by my company and I should actually jsut be getting on with
implementing the suppliers feeds manually.  I figured why not create a tool instead!
Feed a man and he eats for a day, teach him to fish and he'll sell them cheaper than you and run you out of
business kind of thing.

So yes, the code is VERY MESSY and VERY CONFUSING.  Please do not put this on www.TheDailyWTF.com!!!
It is not a reflection of how I code in general.  Plus I am relatively new to C#.

Contact Me
==========

Please attach any XML files which may help in developing this product
To contact me you can send an email to glenb [at] rubixcode.co.za

Change Log
==========
0.0.0.5 - 26 March 2013
 - Fixed some bugs in the conversion algorithym
 - Fixed a bug in the boolean attribute
 - Fixed a bug in the DataTime element

0.0.0.4 - 18 March 2013
 - Fixed a number of bugs (done in a hurry, so code is sh1t, needs a cleanup badly)
 - Added some user-ability
 - Added initial integration for namespaces, plenty research still to be done

0.0.0.3 - 11 Mar 2013
 - Fixed bug in the DateTime Attribute
 - Fixed bug in the Boolean Attribute

0.0.0.2 - 8 Mar 2013
 - Created classes for each element/attribute type
 - Moved code generation into relavant elements/attributes
 - Removed formating from internal code generation
 - Added code formatting function which formats code before writing to file

0.0.0.1 - 3 Mar 2013
 - Initial checkin