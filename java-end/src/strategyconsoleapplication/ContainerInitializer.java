package strategyconsoleapplication;

import java.util.Arrays;

import org.picocontainer.MutablePicoContainer;
import org.picocontainer.PicoBuilder;
import org.picocontainer.PicoContainer;

import strategyconsoleapplication.product.GenderProductRecommender;
import strategyconsoleapplication.product.LowPriceProductRecommender;
import strategyconsoleapplication.product.SeasonalProductRecommender;
import strategyconsoleapplication.sales.SalesEngine;
import strategyconsoleapplication.sales.SalesEngineImpl;

public class ContainerInitializer {

    public static PicoContainer initNewContainer() {
        MutablePicoContainer picoContainer = new PicoBuilder().build();
        picoContainer.addComponent(SalesEngine.class, new SalesEngineImpl(
                Arrays.asList(new GenderProductRecommender(), new LowPriceProductRecommender(), new SeasonalProductRecommender())));
        return picoContainer;
    }
}
