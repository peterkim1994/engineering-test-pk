# Gilded Rose Exercise Notes

## Assumptions
- Small Inn so number of items is assumed to be ~100
- Items with special categories will have the special category at the start of the item name
- Original logic in code is all correct. Ie if the code has business logic that the rules don't then it still valid and needs to be replicated. 
- In the future other developers will update and maintain this system
- Conjured items do not appreciate twice as fast, ie conjured aged brie should remain unchanged
- **Out of ~100 items currently only three need special rules applied.** However, all three existing rules could be applied to new items in the future.
- Possibility of 0-3 more item categories being added in the next year or two.
- The code will/does have to be updated somewhat often since special rules can only be applied by checking the item name. 
 This could easily happen for each future event the shop sells tickets for. Ie the most likely maintenance requirement is to apply existing special rules to new item variants, rather than adding new rules.

## Analysis Notes
- If you only had the code logic to go by, it's possible to interpret the rules differently to what was stated in the read me.
- App only runs correctly if it is run before the next business day starts (9-6pm). Since SellIn value is relative to tomorrow which also makes things a little confusing.

## Considerations
- Order of operations / priority of rules, since different rules for different item categories can stack.
- Readability and maintainability is the highest priority, complexity added from unnecessary abstraction and performance gains will be liabilities

## High level technical approach
- Create unit tests for UpdateQuality() & current behaviour (Will use AI to save time)
- Create strategy for different quality adjustment rule
- Determine item quality updating type strategy to use and then update item

## Design Decisions
- I tried to focus on balancing readability and maintainability. There was no performance considerations made.
- No validation as inventory item names are assumed to be correct.
- I decided on strategy pattern as I felt like it would keep things modular be the most reusable in the future while allowing for the logic flow to be easily understandable.
- Did not add validation to the item quality updater classes as it seems more appropriate that they are item agnostic if possible, and it should be upto the caller to ensure the appropriate item is being passed in.
- I used lists grouping item names because I assume a likely reason a new future developer would have to update the code base is to apply existing rules to new item variants.

## Design trade offs
- Due to the fact this is a small shop and maintenance by other developers being required, I opted not to add complexity by adding extra abstractions or using other design patterns.
Eg the current strategy pattern would not be great for scenarios where new rules/items that affect existing rules need to be added. Either the strategies would need to start being smart enough to apply different logic to certain items OR a new strategy to address each combination of different rules which impact each other.
Eg if the shop also started selling conjured aged brie which does appreciate twice as fast, then you have to unfortunately choose between either adding conjuring logic to the ItemQualityAppreciater strategy, or you would need to add another strategy pattern specifically for this item. However, adding more abstracting or using another design pattern
to account for this would be premature over-engineering.
- If the goblin decided to change the Item class, then this app would need updating since I didn't add a new class to map Item to.

## Generative AI usage
- Item fixtures
- Unit tests (was guided from a high level, and I did have to update some of them manually).