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
        // TBD - Currently we render the Reports page directly... in the future we can add routing (using react-router)
      }
      <Reports />
    </>
  );
}

export default App;
