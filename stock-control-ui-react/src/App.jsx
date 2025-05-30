import { useState } from 'react'
import './App.css'
import AddProductMovement from './modules/features/product-movement/components/add-product-movement/add-product-movement';
import StockReport from './modules/features/reports/components/stock-report/stock-report';

function App() {
  const [displayProductMovements, setDisplayProductMovements] = useState(true);

  let content;

  if (displayProductMovements) {
    content = <AddProductMovement />;
  }
  else {
    content = <StockReport />;
  }

  return (
    <>
      <h1>Welcome to the Stock Control System</h1>

      <div className='flex-container'>
        <div className='flex-item' onClick={() => setDisplayProductMovements(true)}>
          Product Movements
        </div>
        <div className='flex-item' onClick={() => setDisplayProductMovements(false)}>
          Stock Report
        </div>
      </div>

      {content}

    </>
  )
}

export default App
