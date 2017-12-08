
# DNX.Helpers.Console


## ColorType




### F:DNX.Helpers.Console.Background

Refers to background colour


### F:DNX.Helpers.Console.Foreground

Refers to foreground colour


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

### M:DNX.Helpers.Console.GetConsoleWidth(defaultWidth)

Get the current console output window width

| Name | Description |
| ---- | ----------- |
| defaultWidth | *System.Nullable{System.Int32}*<br> |


#### Returns




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


## Exceptions.ReturnCodeException

Class ReturnCodeException.


### M:DNX.Helpers.Console.#ctor(returnCode)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| returnCode | *System.Int32*<br>The return code. |

### M:DNX.Helpers.Console.#ctor(returnCode, message)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| returnCode | *System.Int32*<br>The return code. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.Console.#ctor(returnCode, message, innerException)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| returnCode | *System.Int32*<br>The return code. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |

### F:DNX.Helpers.Console.MaximumReturnCode

The maximum return code


### .ReturnCode

Gets the return code.


