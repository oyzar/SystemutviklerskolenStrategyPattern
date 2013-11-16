package strategyconsoleapplication.interfaces;

import strategyconsoleapplication.Product;
import strategyconsoleapplication.SalesMode;

public interface SalesEngine {
    Product recommend(SalesMode salesMode);
}
