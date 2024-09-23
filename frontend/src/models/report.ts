export type ReportPost = {
  description: string;
  hours: number;
};

export type ReportGet = {
  id: number;
  description: string;
  hours: number;
  createdAt: string;
};
