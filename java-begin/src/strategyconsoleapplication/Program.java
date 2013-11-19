package strategyconsoleapplication;

public class Program {

    public static void main(String [] args) {

        ProgramUsage.checkUsage(args);

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
}
