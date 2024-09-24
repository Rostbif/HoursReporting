/**
 * This file containes the typescript types that equivalent to the server Dtos.
 * It's possible in the future to use TypeGen instead of doing it manually...
 */

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
