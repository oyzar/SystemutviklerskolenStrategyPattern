package strategyconsoleapplication;

import strategyconsoleapplication.interfaces.Customer;
import strategyconsoleapplication.interfaces.Gender;

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

        Product recommendedProduct;

        if (salesMode == SalesMode.GENDER) {
            if (customer.getGender() == Gender.FEMALE) {
                recommendedProduct = new Product("SomeProduct", "For females");
            } else {
                recommendedProduct = new Product("SomeProduct", "For males");
            }
        } else if (salesMode == SalesMode.LOW_PRICE) {
            if (customer.getGender() == Gender.FEMALE) {
                recommendedProduct = new Product("SomeProduct", "For females  and low-cost");
            } else {
                recommendedProduct = new Product("SomeProduct", "For males and low-cost");
            }
        } else if (salesMode == SalesMode.SEASONAL) {
            if (customer.getGender() == Gender.FEMALE) {
                recommendedProduct = new Product("SomeProduct", "For females and seasonal");
            } else {
                recommendedProduct = new Product("SomeProduct", "For males and seasonal");
            }
        } else {
            recommendedProduct = new Product("SomeProduct", "Use some default recommendation??");
        }

        System.out.println(recommendedProduct);
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
