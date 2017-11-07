
# DNX.Helpers.Console


## T:DNX.CommandLine.Helpers.Exceptions.ReturnCodeException

Class ReturnCodeException.


### M:DNX.CommandLine.Helpers.Exceptions.ReturnCodeException.#ctor(returnCode)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| returnCode | *System.Int32*<br>The return code. |

### M:DNX.CommandLine.Helpers.Exceptions.ReturnCodeException.#ctor(returnCode, message)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| returnCode | *System.Int32*<br>The return code. |
| message | *System.String*<br>The message. |

### M:DNX.CommandLine.Helpers.Exceptions.ReturnCodeException.#ctor(returnCode, message, innerException)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| returnCode | *System.Int32*<br>The return code. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |

### P:DNX.CommandLine.Helpers.Exceptions.ReturnCodeException.ReturnCode

Gets the return code.


## ColorType




### F:DNX.Helpers.Console.Background

Refers to background colour


### F:DNX.Helpers.Console.Foreground

Refers to foreground colour


## CommandLine.HelpBuilder

Class HelpBuilder.


### M:DNX.Helpers.Console.GetHelpText``1(parserResult, verbsIndex, consoleWidth)

Gets the help text.

| Name | Description |
| ---- | ----------- |
| parserResult | *CommandLine.ParserResult{``0}*<br>The parser result. |
| verbsIndex | *System.Boolean*<br>if set to true [verbs index]. |
| consoleWidth | *System.Int32*<br>Width of the console. |


#### Returns

System.String.


## CommandLine.ParserHelper

Class ParserHelper.


### .DefaultParser

Gets the default parser.


### F:DNX.Helpers.Console.DefaultParserConfiguration

The default parser configuration


### M:DNX.Helpers.Console.ExpandArgs(args)

Expands the arguments.

| Name | Description |
| ---- | ----------- |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

IEnumerable<System.String>.


### M:DNX.Helpers.Console.Parse``1(parser, args)

Parses the specified arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.String[]*<br>The arguments. |


#### Returns

ParserResult<T>.


### M:DNX.Helpers.Console.ValidateInstance``1(result)

Custom validation on the arguments options instance

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br> |

## CommandLine.ParserResultExtensions

Class ParserResultExtensions.


### M:DNX.Helpers.Console.ErrorResult``1(result)

Errors the result.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

NotParsed<T>.


### M:DNX.Helpers.Console.GetArguments``1(result)

Gets the arguments.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

T.


### M:DNX.Helpers.Console.GetErrors``1(result)

Gets the errors.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

System.Collections.Generic.IEnumerable<CommandLine.Error>.


### M:DNX.Helpers.Console.Ok``1(result)

Oks the specified result.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

true if XXXX, false otherwise.


### M:DNX.Helpers.Console.Result``1(result)

Results the specified result.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

Parsed<T>.


## ConsoleColourChanger

Class ConsoleColourChanger.


### M:DNX.Helpers.Console.#ctor(newColour)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| newColour | *System.ConsoleColor*<br>The new colour. |

### M:DNX.Helpers.Console.#ctor(newColour, type)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| newColour | *System.ConsoleColor*<br>The new colour. |
| type | *DNX.Helpers.Console.ColorType*<br>The type. |

### M:DNX.Helpers.Console.Dispose

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.


### M:DNX.Helpers.Console.GetColour

Gets the colour.


#### Returns

ConsoleColor.


### M:DNX.Helpers.Console.GetColour(type)

Gets the colour.

| Name | Description |
| ---- | ----------- |
| type | *DNX.Helpers.Console.ColorType*<br>The type. |


#### Returns

ConsoleColor.


### M:DNX.Helpers.Console.SetColour(colour)

Sets the colour.

| Name | Description |
| ---- | ----------- |
| colour | *System.ConsoleColor*<br>The colour. |

### M:DNX.Helpers.Console.SetColour(colour, type)

Sets the colour.

| Name | Description |
| ---- | ----------- |
| colour | *System.ConsoleColor*<br>The colour. |
| type | *DNX.Helpers.Console.ColorType*<br>The type. |

## ConsoleHelper




### M:DNX.Helpers.Console.Display




### M:DNX.Helpers.Console.Display(s)



| Name | Description |
| ---- | ----------- |
| s | *System.String*<br> |

### M:DNX.Helpers.Console.Display(s, newline)



| Name | Description |
| ---- | ----------- |
| s | *System.String*<br> |
| newline | *System.Boolean*<br> |

### M:DNX.Helpers.Console.Display(s, wtr)



| Name | Description |
| ---- | ----------- |
| s | *System.String*<br> |
| wtr | *System.IO.TextWriter*<br> |

### M:DNX.Helpers.Console.Display(s, wtr, newline)

Displays the specified s.

| Name | Description |
| ---- | ----------- |
| s | *System.String*<br>The s. |
| wtr | *System.IO.TextWriter*<br>The WTR. |
| newline | *System.Boolean*<br>The newline. |

### M:DNX.Helpers.Console.DisplayAt(y, x, text)

Displays at.

| Name | Description |
| ---- | ----------- |
| y | *System.Int32*<br>The y. |
| x | *System.Int32*<br>The x. |
| text | *System.String*<br>The text. |

### M:DNX.Helpers.Console.DisplayAt(y, x, text, alignment)

Displays at.

| Name | Description |
| ---- | ----------- |
| y | *System.Int32*<br>The y. |
| x | *System.Int32*<br>The x. |
| text | *System.String*<br>The text. |
| alignment | *DNX.Helpers.Console.DisplayAtAlignment*<br>The alignment. |

### M:DNX.Helpers.Console.DisplayError(s)



| Name | Description |
| ---- | ----------- |
| s | *System.String*<br> |

### M:DNX.Helpers.Console.DisplayError(s, changeColour)

Displays the error.

| Name | Description |
| ---- | ----------- |
| s | *System.String*<br>The s. |
| changeColour | *System.Boolean*<br>if set to true [change colour]. |

### M:DNX.Helpers.Console.DisplayHeader(DNX.Helpers.Assemblies.AssemblyDetails)




### M:DNX.Helpers.Console.DisplayHeader(assemblyDetails, headers)

Displays the header.

| Name | Description |
| ---- | ----------- |
| assemblyDetails | *DNX.Helpers.Assemblies.AssemblyDetails*<br>The assembly details. |
| headers | *System.Collections.Generic.IList{System.String}*<br>The headers. |

### M:DNX.Helpers.Console.DisplayHeader(assemblyDetails, headers, writer)

Displays the header.

| Name | Description |
| ---- | ----------- |
| assemblyDetails | *DNX.Helpers.Assemblies.AssemblyDetails*<br>The assembly details. |
| headers | *System.Collections.Generic.IList{System.String}*<br>The headers. |
| writer | *System.IO.TextWriter*<br>The writer. |

### M:DNX.Helpers.Console.DisplayHeader(assemblyDetails, writer)



| Name | Description |
| ---- | ----------- |
| assemblyDetails | *DNX.Helpers.Assemblies.AssemblyDetails*<br> |
| writer | *System.IO.TextWriter*<br> |

### M:DNX.Helpers.Console.MoveTo(y, x)

Moves to.

| Name | Description |
| ---- | ----------- |
| y | *System.Int32*<br>The y. |
| x | *System.Int32*<br>The x. |

## DisplayAtAlignment

Enum DisplayAtAlignment


### F:DNX.Helpers.Console.Centre

The centre


### F:DNX.Helpers.Console.Left

The left


### F:DNX.Helpers.Console.Right

The right


## Interfaces.ISettingsValidator

Interface ISettingsValidator


### M:DNX.Helpers.Console.Validate

Validates this instance.


## T:SampleApp.Arguments

Arguments class for command line


## T:SampleApp.Program

Program controller class


### M:SampleApp.Program.Main(args)

Defines the entry point of the application.

| Name | Description |
| ---- | ----------- |
| args | *System.String[]*<br>The arguments. |


#### Returns

System.Int32.


### M:SampleApp.Program.Run(arguments)

Runs the program using the specified arguments.

| Name | Description |
| ---- | ----------- |
| arguments | *SampleApp.Arguments*<br>The arguments. |

