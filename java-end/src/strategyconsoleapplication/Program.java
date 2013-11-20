package strategyconsoleapplication;

import org.picocontainer.PicoContainer;

import strategyconsoleapplication.sales.SalesEngine;

public class Program {

    public static void main(String [] args) {
        ProgramUsage.checkUsage(args);

        Gender gender = Gender.valueOf(args[0].toUpperCase());
        SalesMode salesMode = SalesMode.valueOf(args[1].toUpperCase());
        Customer customer = new Customer("Customer", gender);

        PicoContainer container = ContainerInitializer.initNewContainer();
        SalesEngine salesEngine = container.getComponent(SalesEngine.class);
        Product recommendedProduct = salesEngine.recommend(salesMode, customer);

        System.out.println(recommendedProduct);
    }

}
