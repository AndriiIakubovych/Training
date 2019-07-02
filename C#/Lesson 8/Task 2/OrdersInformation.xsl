<?xml version="1.0" encoding="utf-16"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Заказы</title>
        <style>
          body { font-family: Arial, sans-serif; }
          th { text-align: center; }
          th, td { padding: 5px; }
        </style>
      </head>
      <body>
        <h1 style="background-color: teal; font-size: 24px; color: white; text-align: center; letter-spacing: 1.0em;">
          Информация о заказах
        </h1>
        <table border="1px" style="border: 1px solid black; border-collapse: collapse;">
          <tbody>
            <tr style="font-size: 16px; font-weight: bold;">
              <th>ФИО клиента</th>
              <th>Дата заказа</th>
              <th>Товары</th>
              <th>Сумма заказа (грн.)</th>
            </tr>
            <xsl:for-each select="orders/order">
              <xsl:sort select="date"/>
              <tr style="font-size: 14px;">
                <td><xsl:value-of select="customer/name"/></td>
                <td><xsl:value-of select="date"/></td>
                <td><ul style="list-style: none; padding: 0; margin: 0;">
                    <xsl:for-each select="products/product">
                      <li><xsl:value-of select="name"/> (<xsl:value-of select="price"/> грн.)</li>
                    </xsl:for-each>
                  </ul>
                </td>
                <td style="padding: 5px; text-align: right;"><xsl:value-of select="sum"/></td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>