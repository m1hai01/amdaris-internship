import { enqueueSnackbar } from "notistack";

export enum SnackbarVariant {
  Success = "success",
  Error = "error",
  Warning = "warning",
  Info = "info",
  Default = "default",
}

export const SnackBarDuration = 5000;

const displayErrorSnackbar = (errorMessage: string): void => {
  enqueueSnackbar(errorMessage, {
    variant: SnackbarVariant.Error,
    autoHideDuration: SnackBarDuration,
    disableWindowBlurListener: true,
    preventDuplicate: true,
  });
};

export default displayErrorSnackbar;
