package strategyconsoleapplication;

import java.util.Map;

import strategyconsoleapplication.interfaces.ProductRecommender;
import strategyconsoleapplication.interfaces.SalesEngine;

public class SalesEngineImpl implements SalesEngine {

    private Map<ProductRecommender, ProductRecommenderMetadata> productRecommenders;

    public SalesEngineImpl(Map<ProductRecommender, ProductRecommenderMetadata> productRecommenders) {
        this.productRecommenders = productRecommenders;
    }

    public Product recommend(SalesMode salesMode) {
        throw new IllegalStateException("Method not implemented");
    }
}
