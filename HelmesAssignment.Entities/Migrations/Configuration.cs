namespace HelmesAssignment.Entities.Migrations
{
    using HelmesAssignment.Entities.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HelmesAssignment.DataLayer.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HelmesAssignment.DataLayer.ApplicationDbContext";
        }

        protected override void Seed(HelmesAssignment.DataLayer.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var manufacturingSector = new Sector(1, "Manufacturing");
            var constructionMaterialsSector = new Sector(19, "Construction materials");
            var electronicAndOpticsSector = new Sector(18, "Electronics and Optics");

            manufacturingSector.Children.Add(constructionMaterialsSector);
            manufacturingSector.Children.Add(electronicAndOpticsSector);

            var foodAndBeverageSector = new Sector(6, "Food and Beverage");
            var bakeryConfectioneryProductsSector = new Sector(342, "Bakery & confectionery products");
            var beveragesSector = new Sector(43, "Beverages");
            var fishFishProductsSector = new Sector(42, "Fish & fish products");
            var meatMeatProductsSector = new Sector(40, "Meat & meat products");
            var milkAndDairyProductsSector = new Sector(39, "Milk & dairy products");
            var foodAndBeveragesOtherSector = new Sector(437, "Other");
            var sweetsAndSnackFoodSector = new Sector(378, "Sweets & snack food");

            foodAndBeverageSector.Children.Add(bakeryConfectioneryProductsSector);
            foodAndBeverageSector.Children.Add(beveragesSector);
            foodAndBeverageSector.Children.Add(fishFishProductsSector);
            foodAndBeverageSector.Children.Add(meatMeatProductsSector);
            foodAndBeverageSector.Children.Add(milkAndDairyProductsSector);
            foodAndBeverageSector.Children.Add(foodAndBeveragesOtherSector);
            foodAndBeverageSector.Children.Add(sweetsAndSnackFoodSector);

            manufacturingSector.Children.Add(foodAndBeverageSector);

            var furnitureSector = new Sector(13, "Furniture");
            furnitureSector.Children.Add(new Sector(389, "Bathroom/sauna"));
            furnitureSector.Children.Add(new Sector(385, "Bedroom"));
            furnitureSector.Children.Add(new Sector(390, "Children's room"));
            furnitureSector.Children.Add(new Sector(98, "Kitchen"));
            furnitureSector.Children.Add(new Sector(101, "Living room"));
            furnitureSector.Children.Add(new Sector(392, "Office"));
            furnitureSector.Children.Add(new Sector(394, "Other (Furniture)"));
            furnitureSector.Children.Add(new Sector(341, "Outdoor"));
            furnitureSector.Children.Add(new Sector(99, "Project furniture"));

            manufacturingSector.Children.Add(furnitureSector);

            var machinerySector = new Sector(12, "Machinery");
            machinerySector.Children.Add(new Sector(94, "Machinery components"));
            machinerySector.Children.Add(new Sector(91, "Machinery equipment/tools"));
            machinerySector.Children.Add(new Sector(224, "Manufacture of machinery"));

            var maritimeSector = new Sector(97, "Maritime");
            maritimeSector.Children.Add(new Sector(271, "Aluminium and steel workboats"));
            maritimeSector.Children.Add(new Sector(269, "Boat/Yacht building"));
            maritimeSector.Children.Add(new Sector(230, "Ship repair and conversion"));

            machinerySector.Children.Add(maritimeSector);

            machinerySector.Children.Add(new Sector(93, "Metal structures"));
            machinerySector.Children.Add(new Sector(508, "Other"));
            machinerySector.Children.Add(new Sector(227, "Repair and maintenance service"));

            manufacturingSector.Children.Add(machinerySector);

            var metalWorkingSector = new Sector(11, "Metalworking");
            metalWorkingSector.Children.Add(new Sector(67, "Construction of metal structures"));
            metalWorkingSector.Children.Add(new Sector(263, "Houses and buildings"));
            metalWorkingSector.Children.Add(new Sector(267, "Metal products"));

            var metalWorksSector = new Sector(542, "Metal works");

            metalWorksSector.Children.Add(new Sector(75, "CNC-machining"));
            metalWorksSector.Children.Add(new Sector(62, "Forgings, Fasteners"));
            metalWorksSector.Children.Add(new Sector(69, "Gas, Plasma, Laser cutting"));
            metalWorksSector.Children.Add(new Sector(66, "MIG, TIG, Aluminum welding"));

            metalWorkingSector.Children.Add(metalWorksSector);

            manufacturingSector.Children.Add(metalWorkingSector);

            var plasticAndRubberSector = new Sector(9, "Plastic and Rubber");
            plasticAndRubberSector.Children.Add(new Sector(54, "Packaging"));
            plasticAndRubberSector.Children.Add(new Sector(556, "Plastic goods"));

            var plasticProcessingTechnologySector = new Sector(559, "Plastic processing technology");
            plasticProcessingTechnologySector.Children.Add(new Sector(55, "Blowing"));
            plasticProcessingTechnologySector.Children.Add(new Sector(57, "Moulding"));
            plasticProcessingTechnologySector.Children.Add(new Sector(53, "Plastics welding and processing"));

            plasticAndRubberSector.Children.Add(plasticProcessingTechnologySector);

            plasticAndRubberSector.Children.Add(new Sector(560, "Plastic profiles"));

            manufacturingSector.Children.Add(plasticAndRubberSector);

            var printingSector = new Sector(5, "Printing");
            printingSector.Children.Add(new Sector(148, "Advertising"));
            printingSector.Children.Add(new Sector(150, "Book/Periodicals printing"));
            printingSector.Children.Add(new Sector(145, "Labelling and packaging printing"));

            manufacturingSector.Children.Add(printingSector);

            var textileAndClothingSector = new Sector(7, "Textile and Clothing");
            textileAndClothingSector.Children.Add(new Sector(44, "Clothing"));
            textileAndClothingSector.Children.Add(new Sector(45, "Textile"));

            manufacturingSector.Children.Add(textileAndClothingSector);

            var woodSector = new Sector(8, "Wood");
            woodSector.Children.Add(new Sector(337, "Other (Wood)"));
            woodSector.Children.Add(new Sector(51, "Wooden building materials"));
            woodSector.Children.Add(new Sector(47, "Wooden houses"));

            manufacturingSector.Children.Add(woodSector);

            var otherSector = new Sector(3, "Other");
            otherSector.Children.Add(new Sector(37, "Creative industries"));
            otherSector.Children.Add(new Sector(29, "Energy technology"));
            otherSector.Children.Add(new Sector(33, "Environment"));

            var serviceSector = new Sector(2, "Service");
            serviceSector.Children.Add(new Sector(25, "Business services"));
            serviceSector.Children.Add(new Sector(35, "Engineering"));

            var itAndTelecommunicationSector = new Sector(28, "Information Technology and Telecommunications");
            itAndTelecommunicationSector.Children.Add(new Sector(581, "Data processing, Web portals, E-marketing"));
            itAndTelecommunicationSector.Children.Add(new Sector(576, "Programming, Consultancy"));
            itAndTelecommunicationSector.Children.Add(new Sector(121, "Software, Hardware"));
            itAndTelecommunicationSector.Children.Add(new Sector(122, "Telecommunications"));

            serviceSector.Children.Add(itAndTelecommunicationSector);

            serviceSector.Children.Add(new Sector(22, "Tourism"));
            serviceSector.Children.Add(new Sector(141, "Translation services"));

            var transportAndLogisticsSector = new Sector(21, "Transport and Logistics");
            transportAndLogisticsSector.Children.Add(new Sector(111, "Air"));
            transportAndLogisticsSector.Children.Add(new Sector(114, "Rail"));
            transportAndLogisticsSector.Children.Add(new Sector(112, "Road"));
            transportAndLogisticsSector.Children.Add(new Sector(113, "Water"));

            serviceSector.Children.Add(transportAndLogisticsSector);

            context.Sectors.AddOrUpdate(x => x.ID, 
                manufacturingSector,
                otherSector,
                serviceSector
            );

        }
    }
}
