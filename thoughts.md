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

