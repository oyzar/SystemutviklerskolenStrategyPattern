package strategyconsoleapplication.sales;

import java.util.HashMap;
import java.util.Map;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Product;
import strategyconsoleapplication.SalesMode;
import strategyconsoleapplication.product.GenderProductRecommender;
import strategyconsoleapplication.product.LowPriceProductRecommender;
import strategyconsoleapplication.product.ProductRecommender;
import strategyconsoleapplication.product.SeasonalProductRecommender;

public class SalesEngineImpl implements SalesEngine {

    private Map<SalesMode, ProductRecommender> productRecommenders;

    public SalesEngineImpl() {
        // TODO saikat: Use a light weight IoC to dependency inject strategies.
        productRecommenders = new HashMap<SalesMode, ProductRecommender>() {{
            put(SalesMode.GENDER, new GenderProductRecommender());
            put(SalesMode.LOW_PRICE, new LowPriceProductRecommender());
            put(SalesMode.SEASONAL, new SeasonalProductRecommender());
        }};
    }

    @Override
    public Product recommend(SalesMode salesMode, Customer customer) {
        return productRecommenders.get(salesMode).recommend(customer);
    }
}
