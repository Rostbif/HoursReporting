import { useState } from "react";
import "./App.css";
import Reports from "./pages/Reports";

function App() {
  const [count, setCount] = useState(0);
  const [reports, setReports] = useState([]);

  return (
    <>
      <h1>Welcome, Ofir Adany</h1>
      {
        // Currently we render the Reports page directly... in the future we can add routing
      }
      <Reports />
      {/* <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p> */}
    </>
  );
}

export default App;
