# Count Expander
Re-hydrates password lists that contain counts. Also contains a utility that will do the opposite and dehydrate a raw password dump into a file of counts (frequencies) against passwords.

## Overview
Some password lists that can be found online are formatted like this:

```
75 password1
56 abc123
29 monkey1
28 iloveyou1
24 myspace1
18 number1
18 football1
17 nicole1
17 123456
16 iloveyou2
16 123abc
15 princess1
15 bubbles1
15 blink182
15 babygirl1
...
```

This utility "expands" or "rehydrates" these password list back into their full form. For instance:

```
3 password
2 hunter
3 nicole
```

Would become:

```
password
password
password
hunter
hunter
nicole
nicole
nicole
```

## Usage
Use the utility like this:

```
.\CountExpander.exe <in_file> [unique_only]
```

The options are quite straightforward:

| Option      | Values      | Required? | Description                                                      |
|-------------|-------------|-----------|------------------------------------------------------------------|
| in_file     | Any         | Yes       | The dehydrated password file.                                    |
| unique_only | Flag (`-u`) | No        | Whether or not to output unique passwords only, defaults to off. |

## Compressor
The compressor utility is used in the same way. It will take raw, newline-delimited password list as a file and spit out a file which contains frequencies against passwords. Use it thusly:

```
.\CountExpander.Compressor.exe <in_file>
```

The options are quite straightforward:

| Option      | Values      | Required? | Description            |
|-------------|-------------|-----------|------------------------|
| in_file     | Any         | Yes       | The raw password file. |
