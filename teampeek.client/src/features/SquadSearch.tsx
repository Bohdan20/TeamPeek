import React, { useState } from 'react';
import {
  CenteredTitle,
  SearchBarWrapper,
  CenteredBox,
  CenteredAlert
} from './SquadSearch.styles';
import type { PlayerInfo, SquadResult } from '../models';
import {
  TextField,
  Button,
  CircularProgress,
  Avatar,
  Box,
  Container,
  TableContainer,
  Table,
  TableHead,
  TableBody,
  TableRow,
  TableCell,
  Paper
} from '@mui/material';

const SquadSearch: React.FC = () => {
  const [team, setTeam] = useState('');
  const [loading, setLoading] = useState(false);
  const [result, setResult] = useState<SquadResult | null>(null);
  const [error, setError] = useState<string | null>(null);

  const handleSearch = async () => {
    setLoading(true);
    setResult(null);
    setError(null);
    try {
      const res = await fetch(`/api/squad?team=${encodeURIComponent(team)}`);
      if (!res.ok) throw new Error('Network error');
      const data: SquadResult = await res.json();
      setResult(data);
    } catch {
      setError('Failed to fetch squad.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <Container maxWidth="md">
      <CenteredTitle variant="h4" gutterBottom>
        Premier League Squad Finder
      </CenteredTitle>
      <SearchBarWrapper>
          <Box display="flex" gap={2}>
            <TextField
              label="Enter team name or nickname"
              variant="outlined"
              value={team}
              onChange={e => setTeam(e.target.value)}
              onKeyDown={e => { if (e.key === 'Enter') handleSearch(); }}
              fullWidth
            />
            <Button variant="contained" color="primary" onClick={handleSearch} disabled={loading || !team.trim()}>
              Search
            </Button>
          </Box>
      </SearchBarWrapper>
      {loading && <CenteredBox><CircularProgress /></CenteredBox>}
      {error && <CenteredAlert severity="error">{error}</CenteredAlert>}
      {result && !result.success && (
        <CenteredAlert severity="warning">{result.error || 'Team not found.'}</CenteredAlert>
      )}
      {result && result.success && result.players && result.players.length > 0 && (
        <TableContainer component={Paper} sx={{ mt: 4 }}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Profile Picture</TableCell>
                <TableCell>First Name</TableCell>
                <TableCell>Surname</TableCell>
                <TableCell>Date of Birth</TableCell>
                <TableCell>Position</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(result.players ?? []).map((player: PlayerInfo) => {
                const [firstName, ...surnameParts] = player.name.split(' ');
                const surname = surnameParts.join(' ');
                return (
                  <TableRow key={player.id}>
                    <TableCell>
                      <Avatar src={player.profilePicture} alt={player.name} />
                    </TableCell>
                    <TableCell>{firstName}</TableCell>
                    <TableCell>{surname}</TableCell>
                    <TableCell>{player.dateOfBirth}</TableCell>
                    <TableCell>{player.position}</TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        </TableContainer>
      )}
      {result && result.success && (!result.players || result.players.length === 0) && (
        <CenteredAlert severity="info">No squad information available for this team.</CenteredAlert>
      )}
    </Container>
  );
};

export default SquadSearch; 