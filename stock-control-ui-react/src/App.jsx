import { useState } from 'react'
import './App.css'
import AddProductMovement from './modules/features/product-movement/components/add-product-movement/add-product-movement';
import StockReport from './modules/features/reports/components/stock-report/stock-report';

function App() {
  const [displayProductMovements, setDisplayProductMovements] = useState(true);

  const content = 
    displayProductMovements
      ? <AddProductMovement />
      : <StockReport />;

  return (
    <>
      <h1 id="mainTitle">Welcome to the Stock Control System</h1>

      <div className='home-page-buttons-container'>
        <div className={`home-page-button ${displayProductMovements ? 'selected' : ''}`} onClick={() => setDisplayProductMovements(true)}>
          Product Movements
        </div>
        <div className={`home-page-button ${!displayProductMovements ? 'selected' : ''}`} onClick={() => setDisplayProductMovements(false)}>
          Stock Report
        </div>
      </div>

      {content}

    </>
  )
}

export default App
