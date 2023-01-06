using NoWait.Models;

namespace NoWait.Data; 

public static class DatabaseInitializer {
    public static void init(NoWaitContext context) {
        context.Database.EnsureCreated();

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

        var walls = new Wall[] {
            new Wall { X = 0, Y = 0, Width = 28, Height = 2 },
            new Wall { X = 0, Y = 2, Width = 2, Height = 18 },
            new Wall { X = 2, Y = 18, Width = 20, Height = 2 },
            new Wall { X = 20, Y = 12, Width = 2, Height = 6 },
            new Wall { X = 22, Y = 12, Width = 6, Height = 2 },
            new Wall { X = 26, Y = 2, Width = 2, Height = 8 }
        };
        
        context.Tables.AddRange(tables);
        context.Charis.AddRange(chairs);
        context.Walls.AddRange(walls);
        context.SaveChanges();
        
        if (context.MenuItems.Any()) {
            return;
        }
        var menuItems = new MenuItem[] {
                new MenuItem{Name="Pasta Carbonara",
                    Description= "Pasta carbonara is an indulgent yet surprisingly simple recipe. Featuring bacon (or pancetta) with plenty of Parmesan, this recipe takes only 30 minutes to prepare from start to finish!", 
                    Price= 10.99f, foodCategory=MenuItem.FoodCategory.Dinner},
                new MenuItem{Name="Green Veggie Burgers",
                    Description= "Serve in buns, over salad, or all on their own. Any way you serve them, don't skip the creamy Green Goddess sauce over top!", 
                    Price= 20, foodCategory=MenuItem.FoodCategory.Lunch},
                new MenuItem{Name="Pasta Carbonara",
                    Description= "Pasta carbonara is an indulgent yet surprisingly simple recipe. Featuring bacon (or pancetta) with plenty of Parmesan, this recipe takes only 30 minutes to prepare from start to finish!", 
                    Price= 10.5f, foodCategory=MenuItem.FoodCategory.Dinner},
                new MenuItem{Name="Green Veggie Burgers",
                    Description= "Serve in buns, over salad, or all on their own. Any way you serve them, don't skip the creamy Green Goddess sauce over top!", 
                    Price= 20.3f, foodCategory=MenuItem.FoodCategory.Lunch},
                new MenuItem{Name="Pasta Carbonara",
                    Description= "Pasta carbonara is an indulgent yet surprisingly simple recipe. Featuring bacon (or pancetta) with plenty of Parmesan, this recipe takes only 30 minutes to prepare from start to finish!", 
                    Price= 10, foodCategory=MenuItem.FoodCategory.Dinner},
                new MenuItem{Name="Green Veggie Burgers",
                    Description= "Serve in buns, over salad, or all on their own. Any way you serve them, don't skip the creamy Green Goddess sauce over top!", 
                    Price= 20, foodCategory=MenuItem.FoodCategory.Lunch},
                new MenuItem{Name="Pasta Carbonara",
                    Description= "Pasta carbonara is an indulgent yet surprisingly simple recipe. Featuring bacon (or pancetta) with plenty of Parmesan, this recipe takes only 30 minutes to prepare from start to finish!", 
                    Price= 10, foodCategory=MenuItem.FoodCategory.Dinner},
                new MenuItem{Name="Green Veggie Burgers",
                    Description= "Serve in buns, over salad, or all on their own. Any way you serve them, don't skip the creamy Green Goddess sauce over top!", 
                    Price= 20, foodCategory=MenuItem.FoodCategory.Lunch}
            };

            context.MenuItems.AddRange(menuItems);
            context.SaveChanges();

        if (context.Ingredients.Any()) {
            return;
        }
        
        string[] items = {"Canola Oil","Chia Seeds","Hazelnut","Pine Nuts",
                "Mustard Oil","Sunflower Seeds","Sesame Oil","Pistachio","Olive Oil","Mustard Seeds","Poppy Seeds",
                "Sesame Seeds","Peanuts","Chironji","Cashew Nuts","Blanched Almonds", "Almonds","Walnuts", // nuts and oilseed
                "Brown Sugar","Sugar Candy","Icing Sugar","Honey","Jaggery","Golden Syrup",
                "Sugar","Castor Sugar","Caramel","Cane Sugar", // Sugar
                "Shrimp","Tuna Fish","Shellfish","Shark","Hilsa","Sardines",
                "Salmon","Prawns","Pomfret","Perch","Mussels","Mullet","Squids","Haddock", "Flounder","Fish Stock",
                "Fish","Fish Fillet","Cuttle fish","Cod","Clams", "Cat fish","Mackerel","Anchovies", // Fish, Seafood
                "Almond Milk","Red Wine Vinegar","Red Wine","Margarine","Soy Milk","White Wine","Yeast",
                "White Pepper","Rice Vinegar","Sea Salt","Hoisin Sauce","Malt Vinegar","Chocolate Chips",
                "Quinoa","Rice Flour","Polenta","Oyster Sauce","Guchchi",
                "Flat Noodles","Balsamic Vinegar","Coconut Oil","Barfi","Rice Noodles","Coffee","Beer","Chocolate",
                "Sake","Vinaigrette","Vanilla Essence","Tortilla","Tomato Puree","Vegetable Oil",
                "Tartaric Acid","Soya Sauce","Vinegar","Sharbat","Vermicelli","Sev","Rum",
                "Roux","Petha","Pasta","Papad","Paan","Meringue","Mayonnaise","Melon Seeds","Lotus Seeds",
                "Vetiver","Screw Pine","Jus","Jelly","Rose Water","Gold Leaves","Glycerine","Gelatin",
                "Fish Sauce","Desiccated Coconut","Cranberry Sauce","Cornflour", "Cognac","Coconut Water",
                "Coconut Milk","Cocoa","Tea","Brown Sauce","Baking Soda","Tofu","Baking Powder",
                "Arrowroot","Egg","Alum","Marzipan","Ajinomoto","Agar", // Other
                "Cranberry","Kiwi","Blueberries","Mango","Watermelon","Tomato",
                "Strawberry","Water Chestnut","Papaya","Orange Rind","Orange","Olives","Pear","Sultana",
                "Mulberry","Lychee","Lemon Juice","Lemon Rind","Lemon","Raisins","Jamun","Tamarind","Grapefruit",
                "Indian Gooseberry","Dried Fruit","Dates","Custard Apple",
                "Currant","Cooking Apples","Coconut","Cherry","Cape Gooseberry","Banana","Peach","Apricots",
                "Apples","Figs","Grapes","Pomegranate","Pineapple","Guava","Plum", // Fruits
                "Gruyere Cheese","Gouda Cheese","Feta Cheese","Milk","Brie Cheese","Cream Cheese",
                "Ricotta Cheese","Parmesan Cheese","Blue Cheese","Cheddar Cheese","Mascarpone Cheese",
                "Cream","Provolone Cheese","Mozzarella Cheese","Khoya","Hung Curd","Yogurt","Cottage Cheese",
                "Condensed Milk","Clarified Butter","Buttermilk","Butter","Sour Cream", // Diary products
                "Beef","Turkey","Skinned Chicken","Pork", "Partridge","Meat Stock","Keema","Mutton Liver","Ham",
                "Kidney Meat","Crab","Chicken Stock","Chicken Liver","Chicken","Chops","Lamb Meat","Quail","Mutton",
                "Bacon", // Meat
                "Amaranth","Flour","Muesli","Oats","Jowar","Brown Rice",
                "Arborio Rice","Water Chestnut flour","Barnyard Millet","Tapioca","Semolina","Finger Millet",
                "Puffed Rice","Buckwheat","Kidney Beans","Green Gram","Flour","Husked Black Gram","Husked Green Gram",
                "Couscous","Cornmeal","Pressed Rice","Rice","Breadcrumbs","Bread","Black-eyed Beans","Black Gram",
                "Black Beans","Gram flour","Bengal Gram","Chickpeas","Basmati Rice","Barley","Pearl Millet",
                "Beansprouts","Pigeon Pea", // Cereal and Pulses
                "Coriander Powder","Chives","Galangal","Tulsi","Sage","Rosemary","Oregano","Nasturtium","Salt",
                "Mustard Powder","Paprika","Mint Leaves",
                "Marjoram","Lemongrass","Red Chilli","Saffron","Dried Fenugreek Leaves","Kashmiri Mirch","Onion Seeds",
                "Mace","Nutmeg","Herbs","Thyme","Turmeric","Garam Masala","Five Spice Powder",
                "Fenugreek Seeds","Fennel","Green Cardamom","Dry Ginger Powder","Dill","Curry Leaves",
                "Cumin Seeds","Coriander Seeds","Coriander Leaves","Cloves","Cinnamon","Cayenne","Caraway Seeds",
                "Cajun Spices", "Rock Salt","Black Pepper","Bay Leaf","Basil","Black Cardamom","Asafoetida","Aniseed",
                "Carom Seeds","Parsley","Acacia", // Spices and Herbs
                "Bok Choy","Snake Beans","Sorrel Leaves","Rocket Leaves",
                "Drumstick","Cherry Tomatoes","Kaffir Lime","Plantain","Turnip","Sweet Potatoes","Round Gourd",
                "Ridge Gourd","Pimiento","Spinach","Onion","Mustard Leaves","Mushroom","Radish",
                "Shallots","Lettuce","Leek","Pumpkin","Yam","Jalapeno","Jackfruit","Horseradish","Spring Onion",
                "Green Peas","Green Chillies","Gherkins","Garlic","French Beans","Fenugreek","Cucumber","Zucchini",
                "Corn","Celery","Cauliflower","Carrot","Capsicum","Capers","Broccoli","Bottle Gourd","Bitter Gourd",
                "Lotus Stem","Pepper","Beetroot","Pigweed","Cabbage","Bamboo Shoot","Baby Corn","Avocado"
                ,"Eggplant","Asparagus","Artichoke","Colocasia","Potatoes","Ginger"};

            Ingredient[] ingredients = new Ingredient[items.Length];
            for(int i=0; i<items.Length; i++) {
                ingredients[i] = new Ingredient {Name = items[i]};
            }

            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();
            
            
    }
}