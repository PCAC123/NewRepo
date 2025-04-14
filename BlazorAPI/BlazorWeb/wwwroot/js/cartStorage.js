window.cartStorage = {
    saveCart: function (userId, data) {
        localStorage.setItem(`cart_${userId}`, data);
    },
    getCart: function (userId) {
        return localStorage.getItem(`cart_${userId}`);
    },
    clearCart: function (userId) {
        localStorage.removeItem(`cart_${userId}`);  
    }
};
