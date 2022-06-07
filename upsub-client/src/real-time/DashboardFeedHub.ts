import { type HubConnection, HubConnectionBuilder } from "@microsoft/signalr";

export class DashboardFeedHub {
  public constructor(private readonly connection: HubConnection) {
    this.setupEvents();
  }

  private setupEvents(): void {
    console.warn("TODO setupEvents");
  }
}

export default class DashboardFeedHubFactory {
  public constructor(private baseUrl: string) {}

  public async create(): Promise<DashboardFeedHub> {
    const connection = this.createHubConnection("dashboard-feed");
    await connection.start();
    return new DashboardFeedHub(connection);
  }

  private createHubConnection(urlResourceName: string): HubConnection {
    const connection = new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}/${urlResourceName}`)
      .build();

    return connection;
  }
}
