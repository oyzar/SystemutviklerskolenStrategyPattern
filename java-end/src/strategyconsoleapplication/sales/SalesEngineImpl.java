package strategyconsoleapplication.sales;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import strategyconsoleapplication.Customer;
import strategyconsoleapplication.Product;
import strategyconsoleapplication.SalesMode;
import strategyconsoleapplication.product.ProductRecommender;

public class SalesEngineImpl implements SalesEngine {

    private Map<SalesMode, ProductRecommender> productRecommenders;

    public SalesEngineImpl(List<ProductRecommender> recommenders) {
        productRecommenders = new HashMap<SalesMode, ProductRecommender>();
        for (SalesMode salesMode : SalesMode.values()) {
            for (ProductRecommender recommender : recommenders) {
                if (recommender.supports(salesMode)) {
                    productRecommenders.put(salesMode, recommender);
                }
            }
        }
    }

    @Override
    public Product recommend(SalesMode salesMode, Customer customer) {
        return productRecommenders.get(salesMode).recommend(customer);
    }
}
