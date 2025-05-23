import './ProductCard.css';

interface ProductCardProps {
  id: number;
  name: string;
  price: number;
  onAdd: () => void;
}

export default function ProductCard({ id, name, price, onAdd }: ProductCardProps) {
  return (
    <div className="product-card">
      <div className="product-info">
        <h3>{name}</h3>
        <p className="price">{price} €</p>
      </div>
      <button className="add-btn" onClick={onAdd} aria-label={`Ajouter ${name} au panier`}>
        Ajouter au panier
      </button>
    </div>
  );
} 