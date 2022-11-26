# Tags
Multi-tags gamedev extension for Unity and C#. Experimental repo.

## Usage purposes
- More flexible tags than Unity built-in (multi-tags per object instead unity's one tag).
- Uses enum instead of strings.
- Can be used to code gameplay behaviour.
- Tags can be stacked.

## How to install
You can install Tags via Unity Package Manager as a git package from Github repository:
```
https://github.com/OlegDzhuraev/Tags.git
```
You also can download it directly from Github and place into the Assets folder.

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

## Usage
Add tag:
```cs
gameObject.AddTag(Tag.Example);
```

Remove tag:
```cs
gameObject.RemoveTag(Tag.Example);
```

Check object has tag:
```cs
if (gameObject.HasTag(Tag.Example))
{
  // do something
}
```

Check object has multiple tags in the same time (like AND condition):
```cs
if (gameObject.HasAllTags(Tag.Example, Tag.Another)) // you can check any amount of tags
{
  // do something
}
```

Check object has any of tags (like OR condition):
```cs
if (gameObject.HasAnyTags(Tag.Example, Tag.Another)) // you can check any amount of tags
{
  // do something
}
```

### Stacking tags
Stacking tags can be useful when several objects affects specific one. 
For example, you have modal windows system in your game and you need to lock player controls if there some modal opened. You can open any amount of modal windows in the same time. 
So, every time you're opening a new window, you're adding new tag ModalOpened to the some WindowLockerObject. When closing window, you're removing one tag.
You can check that player controls should be locked by checking windowLocker.HasTag(Tag.ModalOpened). If this true, input should be locked.

Some features specific for stacking tags:

Count amount of tag. Returns 0 if there no tag, 1 if there one tag, and bigger value if it "stacked":
```cs
gameObject.AddTag(Tag.Example);
int count = gameObject.CountTags(Tag.Example); // result is 1
gameObject.AddTag(Tag.Example);
count = gameObject.CountTags(Tag.Example); // result is 2
```

Prevent adding more than one tag:
```cs
gameObject.AddOnce(Tag.Example); // it will not add a new tag if there already added at least one
```

## License 
MIT
