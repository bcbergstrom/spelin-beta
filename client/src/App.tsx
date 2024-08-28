import { useState } from 'react'
import './App.css'
import Header from './components/header.tsx'


function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <Header bingus={count} setBingus={setCount} />
    </>
  )
}

export default App
