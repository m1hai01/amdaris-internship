import { ErrorCode } from "react-dropzone";

export function convertBytesToMbs(size: number): string {
  return `${(size / 1000000).toFixed(2)} MB`;
}

const FILE_SIZE = 10_000_000;
export const dropzoneErrorsToMessagesMap: ReadonlyMap<string, string> = new Map([
  [ErrorCode.FileTooLarge, `File exceeds ${convertBytesToMbs(FILE_SIZE)}`],
  [ErrorCode.FileInvalidType, "File is not a valid type"],
  [ErrorCode.TooManyFiles, "Too many files"],
]);

export enum DropzoneErrorCodes {
  FileUploaded = "File is already uploaded",
}

export enum DropzoneSuccessCodes {
  FileUploaded = "File uploaded successfully",
  FileDeleted = "File deleted successfully",
  AlertAdded = "Alert added successfully",
  AlertDeleted = "Alert deleted successfully",
}
