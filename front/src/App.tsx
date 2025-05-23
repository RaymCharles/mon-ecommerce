import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { useEffect, useState } from 'react'
import './App.css'

// TypeScript : définition du type Product
interface Product {
  id: number;
  name: string;
  price: number;
}

function Home() {
  const [products, setProducts] = useState<Product[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    // À adapter si l'API tourne sur un autre port
    fetch('http://localhost:5000/api/products')
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
      <ul>
        {products.map((product) => (
          <li key={product.id}>
            <strong>{product.name}</strong> — {product.price} €
          </li>
        ))}
      </ul>
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
  return <div className="container"><h2>Panier</h2><p>À venir…</p></div>;
}

function App() {
  return (
    <Router>
      <nav className="navbar">
        <ul>
          <li><Link to="/">Accueil</Link></li>
          <li><Link to="/products">Produits</Link></li>
          <li><Link to="/orders">Commandes</Link></li>
          <li><Link to="/cart">Panier</Link></li>
        </ul>
      </nav>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/products" element={<Products />} />
        <Route path="/orders" element={<Orders />} />
        <Route path="/cart" element={<Cart />} />
      </Routes>
    </Router>
  )
}

export default App
