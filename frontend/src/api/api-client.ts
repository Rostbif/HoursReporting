import { ReportGet, ReportPost } from "../models/Report";

const API_BASE_URL = "http://localhost:5293";

export const getAllReports = async (): Promise<ReportGet[]> => {
  const response = await fetch(`${API_BASE_URL}/api/reports`);

  if (!response.ok) {
    throw new Error("couldn't fetch reports");
  }

  return response.json();
};

export const createReport = async (report: ReportPost): Promise<ReportGet> => {
  // For testing purposes (server side validation)
  //report = { description: report.description, hours: -1 };

  const response = await fetch(`${API_BASE_URL}/api/reports`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(report),
  });

  if (!response.ok) {
    throw new Error("Couldn't create report");
  }

  return response.json();
};
