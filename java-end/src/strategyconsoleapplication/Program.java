package strategyconsoleapplication;

import strategyconsoleapplication.sales.SalesEngine;
import strategyconsoleapplication.sales.SalesEngineImpl;

public class Program {

    public static void main(String [] args) {

        if (args.length != 2) {
            System.out.println("usage: program gender sales-mode");
            System.out.printf("gender: { %s }\n", Gender.MALE.name().toLowerCase() + ", " + Gender.FEMALE.name().toLowerCase());
            System.out.printf("sales-mode: { %s }\n", getAvailableSalesModes());
            System.exit(- 1);
        }

        Gender gender = Gender.valueOf(args[0].toUpperCase());
        SalesMode salesMode = SalesMode.valueOf(args[1].toUpperCase());
        Customer customer = new Customer("Customer", gender);

        Product recommendedProduct = recommendProduct(salesMode, customer);
        System.out.println(recommendedProduct);
    }

    private static Product recommendProduct(SalesMode salesMode, Customer customer) {
        SalesEngine salesEngine = new SalesEngineImpl();
        return salesEngine.recommend(salesMode, customer);
    }

    private static String getAvailableSalesModes() {
        StringBuilder builder = new StringBuilder();
        SalesMode [] salesModes = SalesMode.values();
        for (int i = 0; i < salesModes.length; i++) {
            SalesMode mode =  salesModes[i];
            builder.append(mode.name().toLowerCase());
            if (i < salesModes.length - 1) {
                builder.append(", ");
            }
        }
        return builder.toString();
    }
}
