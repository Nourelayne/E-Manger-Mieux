import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  const getUserInfo = async () => {
      var request = new Request('/bff/user', {
          method: 'GET',
          credentials: 'include',
          headers: new Headers({
              "Content-Type": "application/json",
              "X-CSRF": "1",
          }),
          cache: "no-store",
      });
      
      const response = await fetch(request);

      if (!response.ok) {
        throw new Error("Could not fetch user information");
      }
      else if (response.status === 401) {
          console.log("user not logged in");
          return false;
      }

      const data = await response.json()

      console.log(data)

      return true;
    }

  useEffect(() => {
    getUserInfo()
  },[])

  return (
    <>
      <div>
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
