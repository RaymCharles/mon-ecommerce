import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { useEffect, useState } from 'react'
import './App.css'
import { CartProvider, useCart } from './CartContext'
import type { CartItem } from './CartContext'
import ProductCard from './ProductCard'

// TypeScript : définition du type Product
interface Product {
  id: number;
  name: string;
  price: number;
  image?: string;
  category?: string;
}

function Home() {
  const [products, setProducts] = useState<Product[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)
  const { addToCart } = useCart()

  useEffect(() => {
    // À adapter si l'API tourne sur un autre port
    fetch('http://localhost:5015/api/products')
      .then((res) => {
        if (!res.ok) throw new Error('Erreur lors du chargement des produits')
        return res.json()
      })
      .then((data) => setProducts(data))
      .catch((err) => setError(err.message))
      .finally(() => setLoading(false))
  }, [])

  return (
    <div className="container">
      <h2>Liste des produits</h2>
      {loading && <p>Chargement...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <div className="products-grid">
        {products.map((product) => (
          <ProductCard
            key={product.id}
            id={product.id}
            name={product.name}
            price={product.price}
            image={product.image}
            category={product.category}
            onAdd={(size) => addToCart(size ? { ...product, name: `${product.name} (${size})` } : product)}
          />
        ))}
      </div>
    </div>
  )
}

function Products() {
  return <Home />;
}

function Orders() {
  return <div className="container"><h2>Commandes</h2><p>À venir…</p></div>;
}

function Cart() {
  const { cart, removeFromCart } = useCart()
  const total = cart.reduce((sum, item) => sum + item.price * item.quantity, 0)
  const { setCart } = useCart() as any
  return (
    <div className="container">
      <h2>Panier</h2>
      {cart.length === 0 ? (
        <p>Votre panier est vide.</p>
      ) : (
        <>
          <ul>
            {cart.map((item: CartItem) => (
              <li key={item.id}>
                <strong>{item.name}</strong> — {item.price} € x {item.quantity}
                <button style={{ marginLeft: 8 }} onClick={() => removeFromCart(item.id)}>
                  Retirer
                </button>
              </li>
            ))}
          </ul>
          <div className="cart-total">Total : {total.toFixed(2)} €</div>
          <div className="cart-actions">
            <button className="empty-cart-btn" onClick={() => setCart([])}>
              Vider le panier
            </button>
          </div>
        </>
      )}
    </div>
  )
}

function Navbar() {
  const { cart } = useCart()
  const count = cart.reduce((sum, item) => sum + item.quantity, 0)
  return (
    <nav className="navbar">
      <ul>
        <li><Link to="/">Accueil</Link></li>
        <li><Link to="/products">Produits</Link></li>
        <li><Link to="/orders">Commandes</Link></li>
        <li><Link to="/cart">Panier {count > 0 && <span>({count})</span>}</Link></li>
      </ul>
    </nav>
  )
}

function App() {
  return (
    <CartProvider>
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/products" element={<Products />} />
          <Route path="/orders" element={<Orders />} />
          <Route path="/cart" element={<Cart />} />
        </Routes>
      </Router>
    </CartProvider>
  )
}

export default App
