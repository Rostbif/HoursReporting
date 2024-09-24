import { useEffect, useState } from "react";
import "./App.css";
import Reports from "./pages/Reports";
import { getAllReports } from "./api/api-client";
import { ReportGet } from "./models/Report";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      {
        // TBD - if we want let's query the name of user from the app context for the "name of the person..." (to prepare for authentication)
      }
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
