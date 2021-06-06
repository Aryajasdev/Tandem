# Business Rules Excercise 
I was given to make a solution with unit test on belos businees rules

Rule # Description
1 If the order contains a physical product, generate a packing slip for shipping.
2 If the order contains a book, create a duplicate packing slip for the royalty
department.
3 If the order contains a membership, activate that membership.
4 If the order contains an upgrade to a membership, apply the upgrade.
5 If the order is for a membership or upgrades, e-mail the owner and inform them
of the activation/upgrade.

Solution: 

I have used 2 design pattern to make the solution
1. Strategy Pattern
2. Factory Pattern

We could have added more engineering with CQRS but it will take time as well as it will be too much engineering, so i did very simple solution with applying above design patterns

We have mainly 3 different strategy and few additional behaviour in above rules 

1. We created a abstract Base class having common properties Product, Book and Membership
2. 3 derived Classes (can have more) with concrete method of purchase coming from Interface IPurchase.
3. All Derived classes implementing different kind of purchase with their implementation.
4. We added 2 behavous of Royalty service and Notification Service which were provided to concrete class in a factory


Please find the Solution attached, use Git Clone and run unit tests to understand the simplest logic could be give to these rules. 
