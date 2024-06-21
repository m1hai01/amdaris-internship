import { FileRejection, ErrorCode } from "react-dropzone";
import displayErrorSnackbar from "./DropzoneErrorSnackbar";
import { dropzoneErrorsToMessagesMap } from "./dropzone-error-Codes";

const onDropRejected = (fileRejections: FileRejection[]): void => {
  fileRejections?.forEach((fileRejection) => {
    const { errors } = fileRejection;
    errors?.forEach((error) => {
      switch (error.code) {
        case ErrorCode.TooManyFiles:
        case ErrorCode.FileInvalidType:
        case ErrorCode.FileTooLarge:
          displayErrorSnackbar(dropzoneErrorsToMessagesMap.get(error.code)!);
          break;
        default:
          displayErrorSnackbar(error.message);
          break;
      }
    });
  });
};

export default onDropRejected;
