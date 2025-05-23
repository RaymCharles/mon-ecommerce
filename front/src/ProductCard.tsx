import './ProductCard.css';
import { useState } from 'react';

interface ProductCardProps {
  id: number;
  name: string;
  price: number;
  image?: string;
  category?: string;
  onAdd: (size?: string) => void;
}

const CLOTHES_SIZES = ['XS', 'S', 'M', 'L', 'XL', 'XXL'];
const SHOES_SIZES = Array.from({ length: 46 - 35 + 1 }, (_, i) => (i + 35).toString());

export default function ProductCard({ id, name, price, image, category, onAdd }: ProductCardProps) {
  const [size, setSize] = useState('');
  const isClothes = category === 'vetement';
  const isShoes = category === 'chaussure';
  const sizes = isClothes ? CLOTHES_SIZES : isShoes ? SHOES_SIZES : [];

  return (
    <div className="product-card">
      {image && <img src={image} alt={name} className="product-img" />}
      <div className="product-info">
        <h3>{name}</h3>
        <p className="price">{price} €</p>
        {sizes.length > 0 && (
          <select
            className="size-select"
            value={size}
            onChange={e => setSize(e.target.value)}
            aria-label="Choisir la taille"
          >
            <option value="">Taille...</option>
            {sizes.map(s => (
              <option key={s} value={s}>{s}</option>
            ))}
          </select>
        )}
      </div>
      <button
        className="add-btn"
        onClick={() => onAdd(size)}
        aria-label={`Ajouter ${name} au panier`}
        disabled={sizes.length > 0 && !size}
      >
        Ajouter au panier
      </button>
    </div>
  );
} 