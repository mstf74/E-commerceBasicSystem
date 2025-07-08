 ## OOP Features & Concepts Used
**Abstraction** :	Defined core interfaces like IShippable and IExpirable to represent behaviors cleanly.
**Encapsulation** :	Internal logic and properties (like balance checks or expiry logic) are safely wrapped inside the appropriate classes.
**Composition** : Products can optionally have behaviors like shipping or expiry via interface composition, not subclassing.
**Interface Segregation** :	No bloated base class — only add behaviors via interfaces if the object needs them.
**Null Object Pattern** : Avoids nulls for optional behavior with safe defaults like NonShippable.
**Single Responsibility** : Principle	Each class handles a specific role: Customer for user info, Cart for managing selected products, Product for item data.
## screen shots:
![image alt](https://github.com/mstf74/E-commerceBasicSystem/blob/e7b153af94ad0e7fd4dd251f755ae5b24d771113/ScreenShots/Screenshot%201.png) 
![image alt](https://github.com/mstf74/E-commerceBasicSystem/blob/e7b153af94ad0e7fd4dd251f755ae5b24d771113/ScreenShots/Screenshot%202.png) 

