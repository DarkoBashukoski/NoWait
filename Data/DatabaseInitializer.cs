using NoWait.Models;

namespace NoWait.Data;

public static class DatabaseInitializer {
    public static void init(NoWaitContext context) {
        context.Database.EnsureCreated();

        AddTables(context);
        AddChairs(context);
        AddWalls(context);
        AddMenuItems(context);
        AddIngredients(context);
        context.SaveChanges();
    }


    private static void AddTables(NoWaitContext context) {
        if (context.Tables.Any()) {
            return;
        }

        var tables = new Table[] {
            new Table { X = 2, Y = 4, Width = 6, Height = 4 },
            new Table { X = 2, Y = 12, Width = 6, Height = 4 },
            new Table { X = 12, Y = 3, Width = 4, Height = 6 },
            new Table { X = 20, Y = 3, Width = 4, Height = 6 },
            new Table { X = 10, Y = 12, Width = 4, Height = 5 },
            new Table { X = 16, Y = 12, Width = 4, Height = 5 }
        };

        context.Tables.AddRange(tables);
    }

    private static void AddChairs(NoWaitContext context) {
        if (context.Charis.Any()) {
            return;
        }

        var chairs = new Chair[] {
            new Chair { X = 3, Y = 3, Width = 2, Height = 2 },
            new Chair { X = 5, Y = 3, Width = 2, Height = 2 },
            new Chair { X = 3, Y = 7, Width = 2, Height = 2 },
            new Chair { X = 5, Y = 7, Width = 2, Height = 2 },
            new Chair { X = 3, Y = 11, Width = 2, Height = 2 },
            new Chair { X = 5, Y = 11, Width = 2, Height = 2 },
            new Chair { X = 3, Y = 15, Width = 2, Height = 2 },
            new Chair { X = 5, Y = 15, Width = 2, Height = 2 },
            new Chair { X = 11, Y = 11, Width = 2, Height = 2 },
            new Chair { X = 11, Y = 16, Width = 2, Height = 2 },
            new Chair { X = 17, Y = 11, Width = 2, Height = 2 },
            new Chair { X = 17, Y = 16, Width = 2, Height = 2 },
            new Chair { X = 11, Y = 4, Width = 2, Height = 2 },
            new Chair { X = 15, Y = 4, Width = 2, Height = 2 },
            new Chair { X = 11, Y = 6, Width = 2, Height = 2 },
            new Chair { X = 15, Y = 6, Width = 2, Height = 2 },
            new Chair { X = 19, Y = 4, Width = 2, Height = 2 },
            new Chair { X = 23, Y = 4, Width = 2, Height = 2 },
            new Chair { X = 19, Y = 6, Width = 2, Height = 2 },
            new Chair { X = 23, Y = 6, Width = 2, Height = 2 }
        };

        context.Charis.AddRange(chairs);
    }

    private static void AddWalls(NoWaitContext context) {
        if (context.Walls.Any()) {
            return;
        }

        var walls = new Wall[] {
            new Wall { X = 0, Y = 0, Width = 28, Height = 2 },
            new Wall { X = 0, Y = 2, Width = 2, Height = 18 },
            new Wall { X = 2, Y = 18, Width = 20, Height = 2 },
            new Wall { X = 20, Y = 12, Width = 2, Height = 6 },
            new Wall { X = 22, Y = 12, Width = 6, Height = 2 },
            new Wall { X = 26, Y = 2, Width = 2, Height = 8 }
        };

        context.Walls.AddRange(walls);
    }

    private static void AddMenuItems(NoWaitContext context) {
        if (context.MenuItems.Any()) {
            return;
        }

        var menuItems = new MenuItem[] {
            new MenuItem {
                Name = "Croissants",
                Description =
                    "Flaky, buttery pastries made with layers of puff pastry and filled with chocolate, almond, or ham and cheese.",
                Price = 3.50f, foodCategory = MenuItem.FoodCategory.Breakfast
            },
            new MenuItem {
                Name = "Pain au chocolat",
                Description =
                    "A type of pastry made with puff pastry and chocolate.",
                Price = 3.50f, foodCategory = MenuItem.FoodCategory.Breakfast
            },
            new MenuItem {
                Name = "Quiche Lorraine",
                Description =
                    "A savory tart made with eggs, cream, and bacon.",
                Price = 12.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Coq au vin",
                Description =
                    "A classic French dish made with chicken braised in red wine.",
                Price = 18.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Beef Wellington",
                Description =
                    "A British dish made with beef tenderloin wrapped in puff pastry.",
                Price = 25.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Cottage pie",
                Description =
                    "A traditional British dish made with minced meat and vegetables topped with mashed potatoes.",
                Price = 15.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Bangers and mash",
                Description =
                    "A British dish made with sausages and mashed potatoes.",
                Price = 12.00f , foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Ploughman's lunch",
                Description =
                    "A traditional British meal made with cheese, bread, and pickles.",
                Price = 10.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Fish and chips",
                Description =
                    "A British dish made with deep-fried fish and chips.",
                Price = 14.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Bubble and squeak",
                Description =
                    "A British dish made with leftover potatoes and vegetables fried together.",
                Price = 10.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Borscht",
                Description =
                    "A soup made with beets and vegetables.",
                Price = 12.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Pierogies",
                Description =
                    "A type of dumpling filled with mashed potatoes and cheese.",
                Price = 10.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Schnitzel",
                Description =
                    "A thin cut of breaded and fried meat.",
                Price = 18.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Goulash",
                Description =
                    "A hearty stew made with beef and vegetables.",
                Price = 15.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Risotto",
                Description =
                    "An Italian dish made with arborio rice and broth.",
                Price = 18.00f, foodCategory = MenuItem.FoodCategory. Dinner
            },
            new MenuItem {
                Name = "Spaghetti carbonara",
                Description =
                    "An Italian dish made with spaghetti, eggs, and bacon.",
                Price = 15.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Lasagna",
                Description =
                    "An Italian dish made with layers of pasta, meat, and cheese.",
                Price = 20.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Tiramisu",
                Description =
                    "An Italian dessert made with mascarpone cheese and coffee-soaked ladyfingers.",
                Price = 8.00f, foodCategory = MenuItem.FoodCategory.Dessert
            },
            new MenuItem {
                Name = "Gelato",
                Description =
                    "An Italian frozen dessert made with cream, milk, and sugar.",
                Price = 6.00f, foodCategory = MenuItem.FoodCategory.Dessert
            },
            new MenuItem {
                Name = "Cannoli",
                Description =
                    "An Italian dessert made with fried pastry dough filled with sweet ricotta cheese.",
                Price = 5.00f, foodCategory = MenuItem.FoodCategory.Dessert
            },
            new MenuItem {
                Name = "Churros",
                Description =
                    "A Spanish dessert made with deep-fried dough and coated in sugar.",
                Price = 5.00f, foodCategory = MenuItem.FoodCategory.Dessert
            },
            new MenuItem {
                Name = "Paella",
                Description =
                    "A Spanish dish made with rice and seafood or chicken.",
                Price = 18.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Gazpacho",
                Description =
                    "A Spanish soup made with raw vegetables and served cold.",
                Price = 8.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Tortilla Española",
                Description =
                    "A Spanish omelette made with potatoes and onions.",
                Price = 10.00f, foodCategory = MenuItem.FoodCategory.Lunch
            },
            new MenuItem {
                Name = "Pintxos",
                Description =
                    "Small appetizers or tapas from the Basque region of Spain, typically served on a slice of bread.",
                Price = 15.00f, foodCategory = MenuItem.FoodCategory.Appetizer
            },
            new MenuItem {
                Name = "Croquetas de jamón",
                Description =
                    " Fried balls of béchamel sauce and ham, a popular tapa in Spain.",
                Price = 8.00f, foodCategory = MenuItem.FoodCategory.Appetizer
            },
            new MenuItem {
                Name = "Schweinshaxe",
                Description =
                    "A Bavarian dish made with roasted ham hock",
                Price = 22.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Schnitzel Wiener Art",
                Description =
                    "A thin cut of breaded and fried veal, a popular dish in Austria.",
                Price = 20.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Wiener Schnitzel",
                Description =
                    "A thin cut of breaded and fried pork, a traditional dish in Austria.",
                Price = 20.00f, foodCategory = MenuItem.FoodCategory.Dinner
            },
            new MenuItem {
                Name = "Apfelstrudel",
                Description =
                    " A sweet pastry filled with apples and raisins, a popular dessert in Austria.",
                Price = 8.00f, foodCategory = MenuItem.FoodCategory.Dessert
            }
        };

        context.MenuItems.AddRange(menuItems);
    }

    private static void AddIngredients(NoWaitContext context) {
        if (context.Ingredients.Any()) {
            return;
        }

        string[] items = {
            "Canola Oil", "Chia Seeds", "Hazelnut", "Pine Nuts",
            "Mustard Oil", "Sunflower Seeds", "Sesame Oil", "Pistachio", "Olive Oil", "Mustard Seeds", "Poppy Seeds",
            "Sesame Seeds", "Peanuts", "Chironji", "Cashew Nuts", "Blanched Almonds", "Almonds",
            "Walnuts", // nuts and oilseed
            "Brown Sugar", "Sugar Candy", "Icing Sugar", "Honey", "Jaggery", "Golden Syrup",
            "Sugar", "Castor Sugar", "Caramel", "Cane Sugar", // Sugar
            "Shrimp", "Tuna Fish", "Shellfish", "Shark", "Hilsa", "Sardines",
            "Salmon", "Prawns", "Pomfret", "Perch", "Mussels", "Mullet", "Squids", "Haddock", "Flounder", "Fish Stock",
            "Fish", "Fish Fillet", "Cuttle fish", "Cod", "Clams", "Cat fish", "Mackerel", "Anchovies", // Fish, Seafood
            "Almond Milk", "Red Wine Vinegar", "Red Wine", "Margarine", "Soy Milk", "White Wine", "Yeast",
            "White Pepper", "Rice Vinegar", "Sea Salt", "Hoisin Sauce", "Malt Vinegar", "Chocolate Chips",
            "Quinoa", "Rice Flour", "Polenta", "Oyster Sauce", "Guchchi",
            "Flat Noodles", "Balsamic Vinegar", "Coconut Oil", "Barfi", "Rice Noodles", "Coffee", "Beer", "Chocolate",
            "Sake", "Vinaigrette", "Vanilla Essence", "Tortilla", "Tomato Puree", "Vegetable Oil",
            "Tartaric Acid", "Soya Sauce", "Vinegar", "Sharbat", "Vermicelli", "Sev", "Rum",
            "Roux", "Petha", "Pasta", "Papad", "Paan", "Meringue", "Mayonnaise", "Melon Seeds", "Lotus Seeds",
            "Vetiver", "Screw Pine", "Jus", "Jelly", "Rose Water", "Gold Leaves", "Glycerine", "Gelatin",
            "Fish Sauce", "Desiccated Coconut", "Cranberry Sauce", "Cornflour", "Cognac", "Coconut Water",
            "Coconut Milk", "Cocoa", "Tea", "Brown Sauce", "Baking Soda", "Tofu", "Baking Powder",
            "Arrowroot", "Egg", "Alum", "Marzipan", "Ajinomoto", "Agar", // Other
            "Cranberry", "Kiwi", "Blueberries", "Mango", "Watermelon", "Tomato",
            "Strawberry", "Water Chestnut", "Papaya", "Orange Rind", "Orange", "Olives", "Pear", "Sultana",
            "Mulberry", "Lychee", "Lemon Juice", "Lemon Rind", "Lemon", "Raisins", "Jamun", "Tamarind", "Grapefruit",
            "Indian Gooseberry", "Dried Fruit", "Dates", "Custard Apple",
            "Currant", "Cooking Apples", "Coconut", "Cherry", "Cape Gooseberry", "Banana", "Peach", "Apricots",
            "Apples", "Figs", "Grapes", "Pomegranate", "Pineapple", "Guava", "Plum", // Fruits
            "Gruyere Cheese", "Gouda Cheese", "Feta Cheese", "Milk", "Brie Cheese", "Cream Cheese",
            "Ricotta Cheese", "Parmesan Cheese", "Blue Cheese", "Cheddar Cheese", "Mascarpone Cheese",
            "Cream", "Provolone Cheese", "Mozzarella Cheese", "Khoya", "Hung Curd", "Yogurt", "Cottage Cheese",
            "Condensed Milk", "Clarified Butter", "Buttermilk", "Butter", "Sour Cream", // Diary products
            "Beef", "Turkey", "Skinned Chicken", "Pork", "Partridge", "Meat Stock", "Keema", "Mutton Liver", "Ham",
            "Kidney Meat", "Crab", "Chicken Stock", "Chicken Liver", "Chicken", "Chops", "Lamb Meat", "Quail", "Mutton",
            "Bacon", // Meat
            "Amaranth", "Flour", "Muesli", "Oats", "Jowar", "Brown Rice",
            "Arborio Rice", "Water Chestnut flour", "Barnyard Millet", "Tapioca", "Semolina", "Finger Millet",
            "Puffed Rice", "Buckwheat", "Kidney Beans", "Green Gram", "Flour", "Husked Black Gram", "Husked Green Gram",
            "Couscous", "Cornmeal", "Pressed Rice", "Rice", "Breadcrumbs", "Bread", "Black-eyed Beans", "Black Gram",
            "Black Beans", "Gram flour", "Bengal Gram", "Chickpeas", "Basmati Rice", "Barley", "Pearl Millet",
            "Beansprouts", "Pigeon Pea", // Cereal and Pulses
            "Coriander Powder", "Chives", "Galangal", "Tulsi", "Sage", "Rosemary", "Oregano", "Nasturtium", "Salt",
            "Mustard Powder", "Paprika", "Mint Leaves",
            "Marjoram", "Lemongrass", "Red Chilli", "Saffron", "Dried Fenugreek Leaves", "Kashmiri Mirch",
            "Onion Seeds",
            "Mace", "Nutmeg", "Herbs", "Thyme", "Turmeric", "Garam Masala", "Five Spice Powder",
            "Fenugreek Seeds", "Fennel", "Green Cardamom", "Dry Ginger Powder", "Dill", "Curry Leaves",
            "Cumin Seeds", "Coriander Seeds", "Coriander Leaves", "Cloves", "Cinnamon", "Cayenne", "Caraway Seeds",
            "Cajun Spices", "Rock Salt", "Black Pepper", "Bay Leaf", "Basil", "Black Cardamom", "Asafoetida", "Aniseed",
            "Carom Seeds", "Parsley", "Acacia", // Spices and Herbs
            "Bok Choy", "Snake Beans", "Sorrel Leaves", "Rocket Leaves",
            "Drumstick", "Cherry Tomatoes", "Kaffir Lime", "Plantain", "Turnip", "Sweet Potatoes", "Round Gourd",
            "Ridge Gourd", "Pimiento", "Spinach", "Onion", "Mustard Leaves", "Mushroom", "Radish",
            "Shallots", "Lettuce", "Leek", "Pumpkin", "Yam", "Jalapeno", "Jackfruit", "Horseradish", "Spring Onion",
            "Green Peas", "Green Chillies", "Gherkins", "Garlic", "French Beans", "Fenugreek", "Cucumber", "Zucchini",
            "Corn", "Celery", "Cauliflower", "Carrot", "Capsicum", "Capers", "Broccoli", "Bottle Gourd", "Bitter Gourd",
            "Lotus Stem", "Pepper", "Beetroot", "Pigweed", "Cabbage", "Bamboo Shoot", "Baby Corn", "Avocado",
            "Eggplant", "Asparagus", "Artichoke", "Colocasia", "Potatoes", "Ginger"
        };

        Ingredient[] ingredients = new Ingredient[items.Length];
        for (int i = 0; i < items.Length; i++) {
            ingredients[i] = new Ingredient { Name = items[i] };
        }

        context.Ingredients.AddRange(ingredients);
    }
}