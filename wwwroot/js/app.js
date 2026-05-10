// Cart Management
class ShoppingCart {
    constructor() {
        this.items = this.loadCart();
        this.updateCartCount();
    }

    loadCart() {
        const saved = localStorage.getItem('foodHeaven_cart');
        if (!saved) return [];

        try {
            const items = JSON.parse(saved);
            // Filter out any invalid menu items (IDs should be 1-9 based on seeded data, or 10000+ for generated)
            const validItems = items.filter(item => item.id >= 1 && item.id <= 100000); // Increased limit to support generated items

            // If we filtered out items, save the cleaned cart
            if (validItems.length !== items.length) {
                console.warn('Removed invalid menu items from cart');
                localStorage.setItem('foodHeaven_cart', JSON.stringify(validItems));
            }

            return validItems;
        } catch (e) {
            console.error('Error loading cart:', e);
            localStorage.removeItem('foodHeaven_cart');
            return [];
        }
    }

    saveCart() {
        console.log('Saving cart to localStorage:', this.items);
        localStorage.setItem('foodHeaven_cart', JSON.stringify(this.items));
        this.updateCartCount();
        console.log('Cart saved successfully. localStorage value:', localStorage.getItem('foodHeaven_cart'));
    }

    setDirectCheckout(item) {
        localStorage.setItem('foodHeaven_direct_checkout', JSON.stringify([item]));
        // Note: we don't clear the cart here, direct checkout is separate
    }

    clearDirectCheckout() {
        localStorage.removeItem('foodHeaven_direct_checkout');
    }

    getCheckoutItems() {
        const direct = localStorage.getItem('foodHeaven_direct_checkout');
        if (direct) {
            return JSON.parse(direct);
        }
        return this.items; // Fallback to cart if no direct item
    }

    addItem(item, silent = false) {
        console.log('addItem called with:', item, 'silent:', silent);
        const existingItem = this.items.find(i => i.id === item.id);

        if (existingItem) {
            existingItem.quantity += 1;
            console.log('Item already exists, increased quantity to:', existingItem.quantity);
        } else {
            this.items.push({
                id: item.id,
                name: item.name,
                price: item.price,
                imageUrl: item.imageUrl,
                quantity: 1,
                customization: item.customization || ''
            });
            console.log('New item added to cart. Total items:', this.items.length);
        }

        this.saveCart();
        if (!silent) {
            this.showNotification(`${item.name} added to order!`);
        }
    }

    addToOrder(item) {
        this.addItem(item, true); // Silent add locally then redirect
        // We will handle redirect in the view
    }

    removeItem(itemId) {
        this.items = this.items.filter(i => i.id !== itemId);
        this.saveCart();
    }

    updateQuantity(itemId, quantity) {
        const item = this.items.find(i => i.id === itemId);
        if (item) {
            if (quantity <= 0) {
                this.removeItem(itemId);
            } else {
                item.quantity = quantity;
                this.saveCart();
            }
        }
    }

    getSubtotal() {
        return this.items.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    }

    getTotal() {
        const subtotal = this.getSubtotal();
        const deliveryFee = subtotal > 0 ? 2.00 : 0;
        const tax = subtotal * 0.10;
        return subtotal + deliveryFee + tax;
    }

    clear() {
        this.items = [];
        this.saveCart();
    }

    updateCartCount() {
        const count = this.items.reduce((sum, item) => sum + item.quantity, 0);
        const badges = document.querySelectorAll('.cart-count');
        badges.forEach(badge => {
            badge.textContent = count;
            badge.style.display = count > 0 ? 'block' : 'none';
        });
    }

    showNotification(message) {
        // Create notification element
        const notification = document.createElement('div');
        notification.className = 'fixed top-4 right-4 bg-primary text-background-dark px-6 py-3 rounded-xl shadow-lg z-50 transform transition-all duration-300 translate-x-0';
        notification.innerHTML = `
            <div class="flex items-center gap-2">
                <span class="material-symbols-outlined">check_circle</span>
                <span class="font-bold">${message}</span>
            </div>
        `;

        document.body.appendChild(notification);

        // Auto remove after 3 seconds
        setTimeout(() => {
            notification.style.transform = 'translateX(400px)';
            setTimeout(() => notification.remove(), 300);
        }, 3000);
    }
}

// Initialize cart
const cart = new ShoppingCart();
let appliedDiscount = 0;
let appliedPromoCode = "";

// Add to cart button handlers
document.addEventListener('DOMContentLoaded', function () {
    // Handle add to cart buttons
    document.querySelectorAll('.add-to-cart').forEach(button => {
        button.addEventListener('click', function (e) {
            e.preventDefault();
            const itemData = {
                id: parseInt(this.dataset.id),
                name: this.dataset.name,
                price: parseFloat(this.dataset.price),
                imageUrl: this.dataset.image
            };
            cart.addItem(itemData);
        });
    });

    // Dark mode toggle
    const darkModeToggle = document.getElementById('darkModeToggle');
    if (darkModeToggle) {
        darkModeToggle.addEventListener('click', function () {
            document.documentElement.classList.toggle('dark');
            localStorage.setItem('darkMode', document.documentElement.classList.contains('dark'));
        });
    }

    // Load dark mode preference
    if (localStorage.getItem('darkMode') === 'true') {
        document.documentElement.classList.add('dark');
    }

    // Payment Method Toggle Logic
    const paymentRadios = document.querySelectorAll('input[name="paymentMethod"]');
    const cardForm = document.getElementById('cardDetailsForm');

    if (cardForm) {
        paymentRadios.forEach(radio => {
            radio.addEventListener('change', function (e) {
                if (e.target.value === 'Cash on Delivery') {
                    cardForm.classList.add('hidden');
                } else {
                    cardForm.classList.remove('hidden');
                    // Smooth scroll to form
                    setTimeout(() => {
                        cardForm.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
                    }, 100);
                }
            });
        });
    }
});

// Cart Page Functions
function renderCartItems() {
    const cartContainer = document.getElementById('cartItemsContainer');
    const emptyCart = document.getElementById('emptyCart');
    const checkoutDetails = document.getElementById('checkoutDetails');

    if (!cartContainer) return;

    if (cart.items.length === 0) {
        cartContainer.innerHTML = '';
        if (emptyCart) {
            emptyCart.classList.remove('hidden');
            emptyCart.classList.add('flex');
        }
        if (checkoutDetails) checkoutDetails.classList.add('hidden');
        cartContainer.classList.add('hidden');
        return;
    }

    if (emptyCart) {
        emptyCart.classList.add('hidden');
        emptyCart.classList.remove('flex');
    }
    if (checkoutDetails) checkoutDetails.classList.remove('hidden');
    cartContainer.classList.remove('hidden');

    cartContainer.innerHTML = cart.items.map(item => `
        <div class="group flex flex-col sm:flex-row gap-4 bg-card-light dark:bg-card-dark p-4 rounded-xl shadow-soft dark:shadow-none border border-gray-100 dark:border-white/5 transition-all hover:border-primary/20">
            <div class="bg-center bg-no-repeat bg-cover rounded-xl w-full sm:w-24 h-24 shrink-0" style="background-image: url('${item.imageUrl}');"></div>
            <div class="flex flex-1 flex-col justify-between gap-3">
                <div class="flex justify-between items-start gap-4">
                    <div>
                        <h3 class="text-text-main dark:text-white text-lg font-bold leading-tight line-clamp-1">${item.name}</h3>
                        ${item.customization ? `<p class="text-text-main/60 dark:text-white/50 text-sm font-medium mt-1">${item.customization}</p>` : ''}
                    </div>
                    <div class="flex gap-2">
                         <button onclick="cart.removeItem(${item.id}); renderCartItems();" class="text-text-main/40 dark:text-white/40 hover:text-red-500 transition-colors">
                            <span class="material-symbols-outlined font-normal">delete</span>
                        </button>
                    </div>
                </div>
                
                <div class="flex items-center justify-between">
                    <p class="text-primary font-bold text-lg">$${(item.price * item.quantity).toFixed(2)}</p>
                    
                    <div class="flex items-center bg-background-light dark:bg-background-dark rounded-lg p-1 border border-gray-200 dark:border-white/10">
                        <button onclick="updateCartQuantity(${item.id}, ${item.quantity - 1})" class="size-8 flex items-center justify-center rounded-md hover:bg-white dark:hover:bg-white/10 text-text-main dark:text-white transition-colors">
                            <span class="material-symbols-outlined text-sm">remove</span>
                        </button>
                        <input class="w-8 bg-transparent text-center text-sm font-bold text-text-main dark:text-white focus:outline-none p-0 border-none" readonly type="number" value="${item.quantity}"/>
                        <button onclick="updateCartQuantity(${item.id}, ${item.quantity + 1})" class="size-8 flex items-center justify-center rounded-md hover:bg-white dark:hover:bg-white/10 text-text-main dark:text-white transition-colors">
                            <span class="material-symbols-outlined text-sm">add</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    `).join('');

    updateCartTotals();

    // Update item count badge
    const itemCount = cart.items.length;
    const badge = document.getElementById('itemCountBadge');
    if (badge) {
        badge.textContent = `${itemCount} Item${itemCount !== 1 ? 's' : ''}`;
    }
}

function updateCartQuantity(itemId, newQuantity) {
    cart.updateQuantity(itemId, newQuantity);
    renderCartItems();
}

function updateCartTotals() {
    const subtotal = cart.getSubtotal();
    const deliveryFee = subtotal > 0 ? 5.00 : 0; // Updated to match view default
    const tax = subtotal * 0.10;
    const total = subtotal + deliveryFee + tax - appliedDiscount;

    updateElementText('subtotal', `$${subtotal.toFixed(2)}`);
    updateElementText('deliveryFee', `$${deliveryFee.toFixed(2)}`);
    updateElementText('tax', `$${tax.toFixed(2)}`);
    updateElementText('discount', `-$${appliedDiscount.toFixed(2)}`);
    updateElementText('total', `$${total.toFixed(2)}`);
    updateElementText('totalButton', `$${total.toFixed(2)}`);

    // Show/hide discount row
    const discountRow = document.getElementById('discountRow');
    if (discountRow) {
        if (appliedDiscount > 0) {
            discountRow.classList.remove('hidden');
        } else {
            discountRow.classList.add('hidden');
        }
    }
}

function updateElementText(id, text) {
    const el = document.getElementById(id);
    if (el) el.textContent = text;
}

// Place Order Function
async function placeOrder() {
    const itemsToOrder = cart.getCheckoutItems();

    if (itemsToOrder.length === 0) {
        alert('Your order is empty!');
        return;
    }

    // Capture Delivery Details
    const customerName = document.getElementById('customerName')?.value.trim() || '';
    const customerPhone = document.getElementById('customerPhone')?.value.trim() || '';
    const deliveryAddress = document.getElementById('deliveryAddressInput')?.value.trim();
    const specialInstructions = document.getElementById('orderNotes')?.value.trim() || '';

    // Capture Payment Method
    const paymentMethodInput = document.querySelector('input[name="paymentMethod"]:checked');
    const paymentMethod = paymentMethodInput ? paymentMethodInput.value : 'Cash on Delivery';

    // Validate Delivery Address
    if (!deliveryAddress) {
        alert('Please enter your delivery address.');
        const addrInput = document.getElementById('deliveryAddressInput');
        if (addrInput) {
            addrInput.focus();
            addrInput.classList.add('ring-2', 'ring-red-500');
            setTimeout(() => addrInput.classList.remove('ring-2', 'ring-red-500'), 3000);
        }
        return;
    }

    // Helper for calculations
    const getSubtotal = (items) => items.reduce((sum, item) => sum + (item.price * item.quantity), 0);
    const subtotal = getSubtotal(itemsToOrder);
    const deliveryFee = subtotal > 0 ? 5.00 : 0;
    const tax = subtotal * 0.10;
    const total = subtotal + deliveryFee + tax - appliedDiscount;

    const orderData = {
        orderItems: itemsToOrder.map(item => ({
            menuItemId: item.id,
            quantity: item.quantity,
            price: item.price,
            customization: item.customization
        })),
        customerName: customerName,
        customerPhone: customerPhone,
        customerEmail: "", // Backend will handle login linkage
        deliveryAddress: deliveryAddress,
        specialInstructions: specialInstructions,
        paymentMethod: paymentMethod,
        subtotal: subtotal,
        deliveryFee: deliveryFee,
        tax: tax,
        promoCode: appliedPromoCode,
        discount: appliedDiscount,
        total: total
    };

    try {
        const response = await fetch('/Order/Create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderData)
        });

        const result = await response.json();

        if (result.success) {
            // Determine what to clear
            if (localStorage.getItem('foodHeaven_direct_checkout')) {
                cart.clearDirectCheckout();
            } else {
                cart.clear();
            }

            window.location.href = `/Order/Confirmation/${result.orderId}`;
        } else {
            alert('Error placing order: ' + result.message);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An error occurred while placing your order.');
    }
}

// Apply Promo Code
async function applyPromoCode() {
    const promoCodeInput = document.getElementById('promoCodeInput');
    const promoCode = promoCodeInput.value.trim();
    if (!promoCode) return;

    const subtotal = cart.getSubtotal();

    try {
        const response = await fetch(`/Order/ApplyPromoCode?promoCode=${promoCode}&subtotal=${subtotal}`);
        const result = await response.json();

        if (result.success) {
            appliedDiscount = result.discount;
            appliedPromoCode = promoCode.toUpperCase();
            
            // Update Totals
            updateCartTotals();
            
            // If we are on checkout page, call its specific total function too
            if (typeof calculateCheckoutTotals === 'function') {
                calculateCheckoutTotals(cart.getCheckoutItems());
            }

            alert(result.message + ` You saved $${result.discount.toFixed(2)}!`);
        } else {
            appliedDiscount = 0;
            appliedPromoCode = "";
            updateCartTotals();
            alert(result.message);
        }
    } catch (error) {
        console.error('Error:', error);
    }
}

// Mobile Menu Toggle
document.addEventListener('DOMContentLoaded', () => {
    const mobileMenuBtn = document.getElementById('mobile-menu-btn');
    const closeMenuBtn = document.getElementById('close-menu-btn');
    const mobileMenu = document.getElementById('mobile-menu');

    if (mobileMenuBtn && mobileMenu && closeMenuBtn) {
        mobileMenuBtn.addEventListener('click', () => {
            mobileMenu.classList.remove('translate-x-full');
            mobileMenu.classList.add('translate-x-0');
            document.body.style.overflow = 'hidden';
        });

        closeMenuBtn.addEventListener('click', () => {
            mobileMenu.classList.add('translate-x-full');
            mobileMenu.classList.remove('translate-x-0');
            document.body.style.overflow = '';
        });
    }
});