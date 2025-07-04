import styled from '@emotion/styled';
import { Box, Paper, Alert, Typography } from '@mui/material';
import Grid from '@mui/material/Grid';

export const CenteredContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 48px;
  width: 100%;
  max-width: 1200px;
  margin-left: auto;
  margin-right: auto;
`;

export const CenteredTitle = styled(Typography)`
  text-align: center;
`;

export const SearchBarWrapper = styled(Box)`
  margin-bottom: 32px;
  max-width: 700px;
  margin-left: auto;
  margin-right: auto;
  width: 100%;
`;

export const CenteredBox = styled(Box)`
  display: block;
  margin-left: auto;
  margin-right: auto;
  text-align: center;
`;

export const PlayerCard = styled(Paper)`
  padding: 16px;
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 260px;
  min-height: 240px;
  box-sizing: border-box;
`;

export const CenteredAlert = styled(Alert)`
  margin-top: 16px;
  margin-left: auto;
  margin-right: auto;
  display: block;
  width: fit-content;
  & .MuiAlert-icon {
    display: none;
  }
`;

export const CenteredGrid = styled(Grid)`
  margin-top: 32px;
  justify-content: stretch;
`; 