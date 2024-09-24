import { useEffect, useState } from "react";
import { createReport, getAllReports } from "../api/api-client";
import { ReportGet } from "../models/Report";

/**
 *
 * Have an empty state if there are no reports + a button for adding a report
 * If there are report, present them in a table (Created date, Description, Hours, Actions (in the future edit/delete))
 * Have an "add report" button on the top of the table
 * The button should add a line to the table with fields to insert data + buttons to save/cancel
 * add validation to the fields
 * By clicking on cancel we should return to the previous state
 * By clicking on save we should send the report to the server and refresh the page
 * Use React Query for fetching data...
 *
 */

const Reports = () => {
  const [reports, setReports] = useState<ReportGet[]>([]);
  const [isAddShown, setIsAddShown] = useState<boolean>(false);

  // Fetching the reports for the first time
  useEffect(() => {
    fetchReports();
  }, []);

  const handleAddOrCancelClick = () => {
    // implement here a logic of adding an "add row"
    setIsAddShown(!isAddShown);
  };

  const handleSaveClick = async () => {
    const response = await createReport({ description: "tune", hours: 3.5 });
    if (response) {
      // Refresh the reports list from the server.
      fetchReports();
    }
  };

  // Fetch reports from the server
  const fetchReports = async () => {
    const response = await getAllReports();
    setReports(response);
  };

  return (
    <div>
      <h1>Reports Page</h1>
      {!isAddShown && (
        <button onClick={handleAddOrCancelClick}> Add Report </button>
      )}
      {isAddShown && (
        // probably should be a form...
        <div>
          <input type="text" placeholder="Enter description"></input>
          <input type="text" placeholder="Enter hours"></input>
          <button type="submit" onClick={handleSaveClick}>
            {" "}
            Save{" "}
          </button>
          <button type="submit" onClick={handleAddOrCancelClick}>
            {" "}
            Cancel{" "}
          </button>
        </div>
      )}
      {reports.length > 0 ? (
        <ol>
          {reports.map((r, index) => {
            return <li key={index}>{r.description}</li>;
          })}
        </ol>
      ) : (
        <div>No Reports to Show!</div>
      )}
    </div>
  );
};

export default Reports;
