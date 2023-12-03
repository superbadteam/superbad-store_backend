namespace BuildingBlock.Core.Domain.Shared.Constants;

public static class Categories
{
    public static Dictionary<string, IEnumerable<string>> GetCategories()
    {
        Dictionary<string, IEnumerable<string>> categories = new();

        categories[Electronics.Name] = Electronics.SubCategories;
        categories[ClothingApparel.Name] = ClothingApparel.SubCategories;
        categories[HomeFurniture.Name] = HomeFurniture.SubCategories;
        categories[BeautyPersonalCare.Name] = BeautyPersonalCare.SubCategories;
        categories[SportsOutdoors.Name] = SportsOutdoors.SubCategories;
        categories[ToysGames.Name] = ToysGames.SubCategories;
        categories[BooksStationery.Name] = BooksStationery.SubCategories;
        categories[JewelryAccessories.Name] = JewelryAccessories.SubCategories;
        categories[HealthWellness.Name] = HealthWellness.SubCategories;
        categories[Automotive.Name] = Automotive.SubCategories;
        categories[PetSupplies.Name] = PetSupplies.SubCategories;
        categories[GardenOutdoor.Name] = GardenOutdoor.SubCategories;

        return categories;
    }
}

public static class Electronics
{
    public const string Name = "Electronics";

    public static readonly List<string> SubCategories = new()
    {
        "Phones",
        "Tablets & E-readers",
        "Laptops & Computers",
        "Audio & Headphones",
        "Cameras & Photography",
        "Wearable Technology"
    };
}

public static class ClothingApparel
{
    public const string Name = "Clothing & Apparel";

    public static readonly List<string> SubCategories = new()
    {
        "Men's Clothing",
        "Women's Clothing",
        "Kids & Baby Clothing",
        "Shoes & Footwear",
        "Activewear",
        "Accessories"
    };
}

public static class HomeFurniture
{
    public const string Name = "Home & Furniture";

    public static readonly List<string> SubCategories = new()
    {
        "Furniture",
        "Home Decor",
        "Bedding & Bath",
        "Kitchen & Dining",
        "Lighting & Lamps"
    };
}

public static class BeautyPersonalCare
{
    public const string Name = "Beauty & Personal Care";

    public static readonly List<string> SubCategories = new()
    {
        "Skincare",
        "Haircare",
        "Makeup & Cosmetics",
        "Fragrances",
        "Personal Care & Hygiene"
    };
}

public static class SportsOutdoors
{
    public const string Name = "Sports & Outdoors";

    public static readonly List<string> SubCategories = new()
    {
        "Exercise & Fitness Equipment",
        "Sports Apparel",
        "Outdoor Gear",
        "Team Sports",
        "Cycling & Biking"
    };
}

public static class ToysGames
{
    public const string Name = "Toys & Games";

    public static readonly List<string> SubCategories = new()
    {
        "Toys for Kids",
        "Board Games",
        "Puzzles",
        "Outdoor Play",
        "Collectibles & Action Figures"
    };
}

public static class BooksStationery
{
    public const string Name = "Books & Stationery";

    public static readonly List<string> SubCategories = new()
    {
        "Fiction & Literature",
        "Non-fiction",
        "Children's Books",
        "Office Supplies",
        "Notebooks & Journals"
    };
}

public static class JewelryAccessories
{
    public const string Name = "Jewelry & Accessories";

    public static readonly List<string> SubCategories = new()
    {
        "Necklaces & Pendants",
        "Earrings",
        "Bracelets & Bangles",
        "Watches",
        "Handbags & Wallets"
    };
}

public static class HealthWellness
{
    public const string Name = "Health & Wellness";

    public static readonly List<string> SubCategories = new()
    {
        "Vitamins & Supplements",
        "Fitness Trackers",
        "Health Monitors",
        "Personal Care"
    };
}

public static class Automotive
{
    public const string Name = "Automotive";

    public static readonly List<string> SubCategories = new()
    {
        "Car Parts & Accessories",
        "Tools & Equipment",
        "Car Care & Maintenance",
        "Electronics & Gadgets"
    };
}

public static class PetSupplies
{
    public const string Name = "Pet Supplies";

    public static readonly List<string> SubCategories = new()
    {
        "Pet Food",
        "Pet Toys & Accessories",
        "Beds & Furniture",
        "Grooming & Care"
    };
}

public static class GardenOutdoor
{
    public const string Name = "Garden & Outdoor";

    public static readonly List<string> SubCategories = new()
    {
        "Plants & Seeds",
        "Outdoor Furniture",
        "Garden Tools",
        "BBQ & Grilling"
    };
}