import { ReportGet, ReportPost } from "../models/Report";

const API_BASE_URL = "https://localhost:7178";

export const getAllReports = async (): Promise<ReportGet[]> => {
  const response = await fetch(`${API_BASE_URL}/api/reports`);

  if (!response.ok) {
    throw new Error("couldn't fetch reports");
  }

  return response.json();
};

// TBD - verify here which type we should return... (not sure I will use it)
export const createReport = async (report: ReportPost) => {
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
