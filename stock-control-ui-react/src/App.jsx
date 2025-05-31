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

  const selectedTheme = localStorage.getItem('theme') || 'dark';

  return (
    <>
      <div style={{ display: 'flex', margin: '20px' }}>
        <div>
          <h1 id="mainTitle">Welcome to the Stock Control System</h1>
        </div>
        <div style={{ flexAlign: 'right', marginLeft: 'auto', marginRight: '20px' }}>
          <select style={{ width: '150px' }} id="themeSelector" class="form-control" onClick={() => { setTheme(document.querySelector('#themeSelector').value) }} defaultValue={selectedTheme}>
            <option value="dark">Dark mode</option>
            <option value="light">Light mode</option>
          </select>
        </div>
      </div>

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
