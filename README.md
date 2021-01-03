# Maritims.Net.BlazorExtensions
After picking up Blazor I soon realised that binding form input controls to various data types didn't work very well, so I wrote this library. All it does currently is provide an ExtendedInputField Blazor component which lets you bind to variables of either type string, double or DateTime.

## Supported data types
* string
* double
* DateTime

## Example
```C#
<ExtendedInputText @bind-Value="@myStringField" DisplayName="Foo" class="form-control" />
<ExtendedInputText @bind-Value="@myDoubleField" DisplayName="Bar" class="form-control" />
<ExtendedInputText @bind-Value="@myDateTimeField" DisplayName="Baz" class="form-control" />
```