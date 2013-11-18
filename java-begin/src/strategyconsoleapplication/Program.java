package strategyconsoleapplication;

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
                recommendedProduct = new Product("Prada purse", "Dream handbag for girls of all ages");
            } else {
                recommendedProduct = new Product("Rollex Sea-Dweller", "Real man's watch");
            }
        } else if (salesMode == SalesMode.LOW_PRICE) {
            if (customer.getGender() == Gender.FEMALE) {
                recommendedProduct = new Product("Økonomi sko", "Stylish shoes for stylish girls with a budget");
            } else {
                recommendedProduct = new Product("Pokal øl", "More beer for men");
            }
        } else if (salesMode == SalesMode.SEASONAL) {
            if (customer.getGender() == Gender.FEMALE) {
                recommendedProduct = new Product("Vinterkjole", "Dream winter dress for girls of all age");
            } else {
                recommendedProduct = new Product("Vinter sykkeldrakt", "For real cyclists");
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
