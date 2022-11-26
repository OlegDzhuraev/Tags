# Tags
Multi-tags gamedev extension for Unity and C#. Experimental repo.

## Usage purposes
- More flexible tags than Unity built-in (multi-tags per object instead unity's one tag).
- Uses enum instead of strings.
- Can be used to code gameplay behaviour.
- Tags can be stacked.

## How to install
Use Unity Package Manager (git import) or copy repo to the project Assets folder.

## Quickstart

First, you need to create enum with your tags, it can look like:
```cs
public enum ExampleTag
{
  DisableMovement = 10,
  IsPoisoned = 20,
  AlternativeAttackEnabled = 30,
  // add your own tags in enum
}
```

Next, you need to initialize Tags system and setup usage of your specific tags enum:
```cs 
// this script should be run somewhere at the game start, before any tags usage occurs.
public class ExampleTagsInit : MonoBehaviour
{
  private void Awake()
  {
    TagsSettings.Init<ExampleTag>();
  }
}
```
Setup is done, now you can use Tags.
You can check the Example files to get more info.

## License 
MIT
