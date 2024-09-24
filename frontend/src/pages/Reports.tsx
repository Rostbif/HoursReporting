import { useEffect, useState } from "react";
import { createReport, getAllReports } from "../api/api-client";
import { ReportGet } from "../models/Report";
import { formatDate } from "../utils/helpers";
import { useForm } from "react-hook-form";

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
export type AddReportFormData = {
  description: string;
  hours: number;
};

const Reports = () => {
  const [reports, setReports] = useState<ReportGet[]>([]);
  const [isAddShown, setIsAddShown] = useState<boolean>(false);

  // using react-hook-form for managing the add report form state and errors
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<AddReportFormData>();

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

  const onAddReportSubmit = handleSubmit(async (data) => {
    // TBD -  check what we get here
    const response = await createReport(data);

    // if we get a response (meaning the creation was succeeded)
    if (response) {
      // Refresh the reports list from the server.
      fetchReports();
    }
  });

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
        <form onSubmit={onAddReportSubmit} style={{ display: "flex" }}>
          <label
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "start",
            }}
          >
            Description:
            <input
              type="text"
              placeholder="Enter description"
              {...register("description", { required: "Required" })}
            ></input>
            <span
              style={{
                color: "red",
                visibility: errors.description ? "visible" : "hidden",
              }}
            >
              {" * "}
              {errors.description?.message}
            </span>
          </label>
          <label
            style={{
              display: "flex",
              flexDirection: "column",
              alignItems: "start",
            }}
          >
            Hours:
            <input
              type="number"
              placeholder="Enter hours"
              {...register("hours", {
                required: "Required",
                min: { value: 0, message: "Should be positive" },
              })}
            ></input>
            <span
              style={{
                color: "red",
                visibility: errors.hours ? "visible" : "hidden",
              }}
            >
              {" * "}
              {errors.hours?.message}
            </span>
          </label>
          <div
            style={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <button type="submit"> Save! </button>
            <button type="button" onClick={handleAddOrCancelClick}>
              {" "}
              Cancel{" "}
            </button>
          </div>
        </form>
      )}
      {reports.length > 0 ? (
        <div>
          <h2> Reports List </h2>
          <ol style={{ listStyleType: "none", padding: "0" }}>
            {reports.map((r, index) => {
              return (
                <li key={index}>
                  <span>
                    {formatDate(r.createdAt)} | {r.description} | {r.hours}
                  </span>
                </li>
              );
            })}
          </ol>
        </div>
      ) : (
        <div>No Reports to Show!</div>
      )}
    </div>
  );
};

export default Reports;
