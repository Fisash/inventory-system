# inventory-system
universal inventory system, for computer games, written in the C# language for the Unity engine
## installing
create an inventory folder in the Assets folder of your project and put the Scripts, Prefabs, Items folders there

## hierarchy
for scripts to work, a clear hierarchy of inventory objects on the stage must be observed.

the root object must contain 2 child objects: **inventory slots** and a **mouse slot**. the inventory script hangs on the **inventory slots**.
**Inventory slots** contains all inventory slots, each consists of a **background image**, under which there is an **image of an item**, under which there is a **text with a quantity**. the slot script hangs on the **image of the item**

![example](https://github.com/Fisash/inventory-system/blob/main/images/hierarchy.jpg)

## configuring the inspector
the item image object contains the button component. when you click on it, the Topslot method should be called in the arguments to which the slot index is specified

![example](https://github.com/Fisash/inventory-system/blob/main/images/slot_inspector.jpg)
