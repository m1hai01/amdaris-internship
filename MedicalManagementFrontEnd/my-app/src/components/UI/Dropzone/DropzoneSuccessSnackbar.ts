import { enqueueSnackbar } from "notistack";
import { SnackbarVariant, SnackBarDuration } from "./DropzoneErrorSnackbar";

const displaySuccessSnackbar = (successMessage: string): void => {
  enqueueSnackbar(successMessage, {
    variant: SnackbarVariant.Success,
    autoHideDuration: SnackBarDuration,
    disableWindowBlurListener: true,
    preventDuplicate: true,
  });
};

export default displaySuccessSnackbar;
