# East Side Games Technical Test Notes
Brandon Dahn

---

First thoughts:
* transform.Find followed by GetComponent, too inefficient, has to go
* Text can be interpolated
* Why is "nothing" an option? You can't pick nothing in rock, paper, scissors.
* Using hashtables to pass in values to a simple type like Player is unnecessarily expensive, hides the arguments of Player, and boxes the value-types
* Some fields/methods have inconsistent naming
	* I want to change the naming convention to match Microsoft's recommendations.
	* Some names are not descriptive enough
* I want to add nullable annotations, as there's no guarantees of non-nullability, nor are there appropriate checks/guards.

---

Plan of attack:
1. Enable nullable anotations and fix any compile errors
1. Fix/change names to be more descriptive and consistent. This will also give me a deeper understanding of the code before I make any systemic changes.
1. Add serialized references to GameController
1. Evaluate the overall architecture

---

This is going to be a lot of changes. I'm going to need to make a git in case I want to revert anything.

---

Thoughts while I'm editting names:
* I don't see any benefit to having an OnLoaded event. I would rather pass in a callback to Load, or better yet: no callback. It's not asynchornous after all. If it were, then I'd want a callback or task.
	* Same with UpdateGameLoader.
	* I think I'm going to treat these as if they were asynchronous, and restructure them accordingly.
* I think I'd rather use a ScriptableObject for the mock data. Easier to edit in the editor.
* HandlePlayerInput does not have any validation between converting between int and "UseableItem".
* I want to change Player's private properties to be a property with a public getter, and a private setter.
* I definitely want to change the Hashtable. I don't like the boxing and the weak typing.
* UseableItem is in its own file, but Result is not.
* There's no documentation anywhere. A lot of it doesn't need it, especially after my renaming, as each function is pretty single use. But I should do a pass on this before I'm done just to make sure there's no confusion.

---

